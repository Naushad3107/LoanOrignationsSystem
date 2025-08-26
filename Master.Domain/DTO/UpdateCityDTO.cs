using LOSApplicationApi.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.DTO
{
    public class UpdateCityDTO
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public byte IsActive { get; set; }

        public States States { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
