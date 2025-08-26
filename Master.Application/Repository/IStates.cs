using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IStates
    {
        void AddState(AddStateDTO state);
        List<FetchStateDTO> FetchStates();
        FetchStateDTO FetchStateById(int id);
        void UpdateState(UpdateStatesDTO state);
        void DeleteState(int id);
    }
}
