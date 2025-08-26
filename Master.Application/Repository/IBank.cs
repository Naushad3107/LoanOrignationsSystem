using LOSApplicationApi.DTO;
using LOSApplicationApi.Model;

namespace LOSApplicationApi.Repository
{
    public interface IBank
    {
        void AddBank(AddBankDTO b);
        List<FetchBankDTO> FetchBanks();
        
        FetchBankDTO FetchBankById(int id);
        void UpdateBank(UpdateBankDTO b);
        void DeleteBank(int id);
    }
}
