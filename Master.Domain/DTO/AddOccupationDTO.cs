namespace LOSApplicationApi.DTO
{
    public class AddOccupationDTO
    {
        public string OccupationCode { get; set; }
        public string OccupationName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
