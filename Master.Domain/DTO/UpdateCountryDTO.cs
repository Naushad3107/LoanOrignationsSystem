using LOSApplicationApi.Model;

namespace LOSApplicationApi.DTO
{
    public class UpdateCountryDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public byte IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
