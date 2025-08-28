using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.DTO
{
    public class FetchUserRolesDTO
    {
        public int UserRoleId { get; set; }

        public string UserName { get; set; }

        public string RoleName { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
