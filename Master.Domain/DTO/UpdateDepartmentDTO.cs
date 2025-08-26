using LOSApplicationApi.Model;

namespace LOSApplicationApi.DTO
{
    public class UpdateDepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
