using LOSApplicationApi.Model;

namespace LOSApplicationApi.DTO
{
    public class UpdateOccupationDTO
    {
        public int OccupationTypeId { get; set; }
        public string OccupationCode { get; set; }
        public string OccupationName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte IsDeleted { get; set; }
    }
}
