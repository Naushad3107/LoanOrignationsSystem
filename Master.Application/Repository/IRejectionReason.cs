using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IRejectionReason
    {
        void AddRejectionReason(AddRejectionReasonDTO rejectionReason);
        List<FetchRejectionReasonDTO> FetchRejectionReasons();
        FetchRejectionReasonDTO FetchRejectionReasonById(int id);
        void UpdateRejectionReason(UpdateRejectionReasonDTO rejectionReason);
        void DeleteRejectionReason(int id);
    }
}
