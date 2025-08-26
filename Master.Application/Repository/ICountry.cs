using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface ICountry
    {
        public void AddCountry(AddCountryDTO country);
        List<FetchCountryDTO> FetchCountry();
        FetchCountryDTO FetchCountryById(int id);
        void UpdateCountry(UpdateCountryDTO country);
        void DeleteCountry(int id);
    }
}
