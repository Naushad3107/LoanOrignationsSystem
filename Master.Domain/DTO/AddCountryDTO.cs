namespace LOSApplicationApi.DTO
{
    public class AddCountryDTO
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
