using Master.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace LOSApplicationApi.Model
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte IsDeleted { get; set; }

        public List<UserRoles> UserRoles { get; set; }

        public List<RolePermissions> RolePermissions { get; set; }
    }
 }
