using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.DTO
{
    public class AddUserRolesDTO
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
