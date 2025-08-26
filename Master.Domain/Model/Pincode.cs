using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOSApplicationApi.Model
{
    public class Pincode
    {
        [Key]
        public int PincodeId { get; set; }
        public string Pincodes { get; set; }
        public string Area { get; set; }

        [ForeignKey("Cities")]
        public int CityId { get; set; }
        [ForeignKey("States")]
        public int StateId { get; set; }
        [ForeignKey("Countries")]
        public int CountryId { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte IsDeleted { get; set; }
        // Navigation properties
        public Cities City { get; set; }
        public States State { get; set; }
        public Countries Country { get; set; }

    }
}
