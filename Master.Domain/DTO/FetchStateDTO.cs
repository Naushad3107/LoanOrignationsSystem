using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.DTO
{
    public class FetchStateDTO
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
