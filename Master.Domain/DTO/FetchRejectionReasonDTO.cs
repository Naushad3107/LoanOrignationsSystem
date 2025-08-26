namespace LOSApplicationApi.DTO
{
    public class FetchRejectionReasonDTO
    {
        public int ReasonId { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonText { get; set; }
        public string Category { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
