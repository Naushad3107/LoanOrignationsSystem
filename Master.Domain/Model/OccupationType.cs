using System.ComponentModel.DataAnnotations;

namespace LOSApplicationApi.Model
{
    public class OccupationType
    {
        [Key]
        public int OccupationTypeId { get; set; }
        public string OccupationCode { get; set; }
        public string OccupationName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte IsDeleted { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
