using LOSApplicationApi.Model;

namespace LOSApplicationApi.DTO
{
    public class UpdateRoleDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
