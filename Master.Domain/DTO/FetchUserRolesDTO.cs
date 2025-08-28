using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.DTO
{
    public class FetchUserRolesDTO
    {
        public int UserRoleId { get; set; }

        public int UserName { get; set; }

        public int RoleName { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
