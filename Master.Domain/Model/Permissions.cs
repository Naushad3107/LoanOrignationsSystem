using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.Model
{
    public class Permissions
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        public string PermissionName { get; set; }

        public string Description { get; set; }


        public byte IsActive { get; set; }

        public byte IsDeleted { get; set; }

        public List<RolePermissions> RolePermissions { get; set; }
    }
}
