namespace LOSApplicationApi.DTO
{
    public class AddRejectionReasonDTO
    {
        public string ReasonCode { get; set; }
        public string ReasonText { get; set; }
        public string Category { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
