using System.ComponentModel.DataAnnotations;

namespace LOSApplicationApi.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte IsDeleted { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
