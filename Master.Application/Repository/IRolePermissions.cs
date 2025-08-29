using Master.Domain.DTO.RolePermissionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Application.Repository
{
    public interface IRolePermissions
    {
        void AssignPermissionsToRole(AddRolePermissionDTO rolepermission);
        void RemovePermissionsFromRole(RemoveRolePermissionDTO removerolepermission);
        FetchRolePermissionsDTO GetPermissionsByRoleId(int roleId);

        List<FetchRolePermissionsDTO> GetRolePermissions();
    }
}
