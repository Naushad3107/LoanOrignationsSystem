namespace LOSApplicationApi.DTO
{
    public class UpdateDocumentTypeDTO
    {
        public int DocumentTypeId { get; set; }
        public string DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
