using System.ComponentModel.DataAnnotations;

namespace LOSApplicationApi.Model
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }
        public string DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte IsDeleted { get; set; }
    }
}
