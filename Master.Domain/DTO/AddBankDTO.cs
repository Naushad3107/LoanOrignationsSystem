namespace LOSApplicationApi.DTO
{
    public class AddBankDTO
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
