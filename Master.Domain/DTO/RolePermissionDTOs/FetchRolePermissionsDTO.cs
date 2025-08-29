using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.DTO.RolePermissionDTOs
{
    public class FetchRolePermissionsDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public List<int> PermissionIds { get; set; }
        public List<string> PermissionNames { get; set; }

        public List<string> SubModuleNames { get; set; }
    }

}
