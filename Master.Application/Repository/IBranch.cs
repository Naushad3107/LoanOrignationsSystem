using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IBranch
    {
        void AddBranch(AddBranchDTO branch);
        List<FetchBranchDTO> FetchBranches();

        FetchBranchDTO FetchBranchById(int id);
        void UpdateBranch(UpdateBranchDTO branch);
        void DeleteBranch(int id);
    }
}
