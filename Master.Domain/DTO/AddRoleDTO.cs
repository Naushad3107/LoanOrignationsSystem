using LOSApplicationApi.Model;

namespace LOSApplicationApi.DTO
{
    public class AddRoleDTO
    {

        public string RoleName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
