namespace LOSApplicationApi.DTO
{
    public class AddBranchDTO
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
