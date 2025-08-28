using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.DTO
{
    public class FetchPincodeDTO
    {
        public int PincodeId { get; set; }
        public string Pincodes { get; set; }
        public string Area { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
