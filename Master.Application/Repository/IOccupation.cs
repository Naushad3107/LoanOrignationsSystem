using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IOccupation
    {
        void AddOccupation(AddOccupationDTO occupation);
        List<FetchOccupationDTO> FetchOccupations();
        FetchOccupationDTO FetchOccupationById(int id);
        void UpdateOccupation(UpdateOccupationDTO occupation);
        void DeleteOccupation(int id);
    }
}
