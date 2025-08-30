using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.DTO.RolePermissionDTOs
{
    public class AddRolePermissionDTO
    {
        public int RoleId { get; set; }
        public List<int> PermissionIds { get; set; }

        public int SubModuleId { get; set; }
    }
}
