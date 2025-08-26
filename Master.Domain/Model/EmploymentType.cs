using System.ComponentModel.DataAnnotations;

namespace LOSApplicationApi.Model
{
    public class EmploymentType
    {
        [Key]
        public int EmployementTypeId { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte IsDeleted { get; set; }
    }
}
