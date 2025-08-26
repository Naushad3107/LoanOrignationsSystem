namespace LOSApplicationApi.DTO
{
    public class UpdatePincodeDTO
    {
        public int PincodeId { get; set; }
        public string Pincodes { get; set; }
        public string Area { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public byte IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
