using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface ICity
    {
        void AddCity(AddCityDTO city);
        List<FetchCityDTO> FetchCities();
        FetchCityDTO FetchCityById(int id);
        void UpdateCity(UpdateCityDTO city);
        void DeleteCity(int id);
    }
}
