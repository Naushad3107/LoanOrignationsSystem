using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.DTO
{
    public class AddCityDTO
    {
        public string CityName { get; set; }
        public int StateId { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
