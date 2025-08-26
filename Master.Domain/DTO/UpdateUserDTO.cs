using LOSApplicationApi.Model;
using System.ComponentModel.DataAnnotations;

namespace LOSApplicationApi.DTO
{
    public class UpdateUserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public byte IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
