using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.DTO
{
    public class FetchCityDTO
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
