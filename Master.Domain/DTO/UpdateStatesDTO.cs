using LOSApplicationApi.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.DTO
{
    public class UpdateStatesDTO
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public byte IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
