using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.DTO
{
    public class AddPincodeDTO
    {
        public string Pincodes { get; set; }
        public string Area { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
