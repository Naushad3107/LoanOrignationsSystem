namespace LOSApplicationApi.DTO
{
    public class UpdateEmployementTypeDTO
    {
        public int EmployementTypeId { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
