using LOSApplicationApi.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.Model
{
    public class RolePermissions
    {
        [Key]
        public int RolePermissionId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [ForeignKey("Permission")]
        public int PermissionId { get; set; }

        [ForeignKey("SubModule")]
        public int SubModuleId { get; set; }

        public byte IsActive { get; set; }

        public byte IsDeleted { get; set; }


        // Navigation properties

        public Permissions Permission { get; set; }
        public SubModule SubModule { get; set; }

        public Roles Role { get; set; }

    }
}
