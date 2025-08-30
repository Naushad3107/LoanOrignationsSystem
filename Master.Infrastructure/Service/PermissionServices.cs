using AutoMapper;
using LOSApplicationApi.Data;
using Master.Application.Repository;
using Master.Domain.DTO.PermissionDTOs;
using Master.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Infrastructure.Service
{
    public class PermissionServices : IPermission
    {
        ApplicationDbContext db;
        IMapper mapper;

        public PermissionServices(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public void AddPermission(AddPermissionDTO permission)
        {
            var perm = mapper.Map<Permissions>(permission);
            db.Permissions.Add(perm);
            db.SaveChanges();
        }

        public void DeletePermission(int id)
        {
           bool ifreferenced = db.RolePermissions.Any(rp => rp.PermissionId == id);
            if (ifreferenced)
            {
                throw new Exception("Permission is referenced in RolePermissions, cannot delete.");
            }
            else
            {
                var permission = db.Permissions.FirstOrDefault(x => x.PermissionId == id);
                if (permission != null)
                {
                    permission.IsDeleted = 1;
                }
                db.SaveChanges();
            }
        }

        public FetchPermissionDTO FetchPermissionById(int id)
        {

            var data = db.Permissions.FirstOrDefault(x => x.PermissionId == id && x.IsActive == 1 && x.IsDeleted == 0);
            var map = mapper.Map<FetchPermissionDTO>(data);
            return map;

        }

        public List<FetchPermissionDTO> ViewPermissions()
        {
            var data = db.Permissions.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
            var mappedData = mapper.Map<List<FetchPermissionDTO>>(data);

            return mappedData;
        }
    }
}
