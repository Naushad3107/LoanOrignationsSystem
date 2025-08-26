using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IPincode
    {
        void AddPincode(AddPincodeDTO pincode);
        List<FetchPincodeDTO> FetchPincodes();
        void UpdatePincode(UpdatePincodeDTO pincode);
        FetchPincodeDTO FetchPincodeById(int id);
        void DeletePincode(int id);
    }
}
