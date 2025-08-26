namespace LOSApplicationApi.DTO
{
    public class AddDepartmentDTO
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
