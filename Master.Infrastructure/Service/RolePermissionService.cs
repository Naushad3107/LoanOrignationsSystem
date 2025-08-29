using AutoMapper;
using LOSApplicationApi.Data;
using Master.Application.Repository;
using Master.Domain.DTO.RolePermissionDTOs;
using Master.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Infrastructure.Service
{
    public class RolePermissionService : IRolePermissions
    {
        ApplicationDbContext db;
        IMapper mapper;
        public RolePermissionService(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public void AssignPermissionsToRole(AddRolePermissionDTO rolepermission)
        {
            // Get existing permissions for the role
            var existingPermissions = db.RolePermissions
                .Where(rp => rp.RoleId == rolepermission.RoleId && rp.SubModuleId == rolepermission.SubModuleId)
                .Select(rp => rp.PermissionId)
                .ToHashSet();

            // Build new RolePermission entities for only non-existing ones
            var newPermissions = rolepermission.PermissionIds
                .Where(pid => !existingPermissions.Contains(pid))
                .Select(pid => new RolePermissions
                {
                    RoleId = rolepermission.RoleId,
                    SubModuleId = rolepermission.SubModuleId,
                    PermissionId = pid
                })
                .ToList();

            if (newPermissions.Any())
            {
                db.RolePermissions.AddRange(newPermissions);
                db.SaveChanges();
            }
        }




        public FetchRolePermissionsDTO GetRolePermissions(int roleId)
        {
            var data = db.RolePermissions
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .Include(rp => rp.SubModule)
                .Where(rp => rp.RoleId == roleId)
                .ToList();

            if (!data.Any())
                return null;

            var dto = new FetchRolePermissionsDTO
            {
                RoleId = roleId,
                RoleName = data.First().Role.RoleName,

                PermissionIds = data.Select(rp => rp.PermissionId).Distinct().ToList(),
                PermissionNames = data.Select(rp => rp.Permission.PermissionName).Distinct().ToList(),
                SubModuleNames = data.Select(rp => rp.SubModule.SubModuleName).Distinct().ToList()
            };

            return dto;
        }


        public void RemovePermissionsFromRole(RemoveRolePermissionDTO removerolepermission)
        {
            bool ifreferenced = db.UserRole.Any(ur => ur.RoleId == removerolepermission.RoleId);
            if (ifreferenced)
            {
                throw new Exception("Role is referenced in UserRoles, cannot remove permissions.");
            }
            else
            {
                var permissionsToRemove = db.RolePermissions
                    .Where(rp => rp.RoleId == removerolepermission.RoleId && removerolepermission.PermissionIds.Contains(rp.PermissionId))
                    .ToList();
                if (permissionsToRemove.Any())
                {
                    db.RolePermissions.RemoveRange(permissionsToRemove);
                    db.SaveChanges();
                }
            }
        }

        public List<FetchRolePermissionsDTO> GetRolePermissions()
        {
            var data = db.RolePermissions
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .Include(rp => rp.SubModule)
                .ToList();
            var groupedData = data
                .GroupBy(rp => new { rp.RoleId, rp.Role.RoleName })
                .Select(g => new FetchRolePermissionsDTO
                {
                    RoleId = g.Key.RoleId,
                    RoleName = g.Key.RoleName,
                    PermissionIds = g.Select(rp => rp.PermissionId).Distinct().ToList(),
                    PermissionNames = g.Select(rp => rp.Permission.PermissionName).Distinct().ToList(),
                    SubModuleNames = g.Select(rp => rp.SubModule.SubModuleName).Distinct().ToList()
                })
                .ToList();
            return groupedData;
        }

        public FetchRolePermissionsDTO GetPermissionsByRoleId(int roleId)
        {
            var role = db.Role.FirstOrDefault(r => r.RoleId == roleId);
            if (role == null) return null;

            var permissions = db.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => new
                {
                    rp.PermissionId,
                    rp.Permission.PermissionName,

                })
                .ToList();

            return new FetchRolePermissionsDTO
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                PermissionIds = permissions.Select(p => p.PermissionId).ToList(),
                PermissionNames = permissions.Select(p => p.PermissionName).ToList(),

            };
        }
    }
}
