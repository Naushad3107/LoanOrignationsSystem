using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class CountryServices: ICountry
    {
        ApplicationDbContext db;
        IMapper mapper;
        public CountryServices(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddCountry(AddCountryDTO country)
        {
            var details = mapper.Map<Model.Countries>(country);
            db.Country.Add(details);
            db.SaveChanges();
        }

        public List<FetchCountryDTO> FetchCountry()
        {
            var details = db.Country.Where(x => x.IsActive == 1 && x.IsDeleted == 0).Where(x=>x.IsActive==1&&x.IsDeleted==0).ToList();
            var mappedDetails = mapper.Map<List<FetchCountryDTO>>(details);
            return mappedDetails;
        }

        public FetchCountryDTO FetchCountryById(int id)
        {
            var data = db.Country.Where(x => x.IsActive == 1 && x.IsDeleted == 0).FirstOrDefault(c => c.CountryId == id);
            if (data != null)
            {
                var mappedData = mapper.Map<FetchCountryDTO>(data);
                return mappedData;
            }
            return null;
        }

        public void UpdateCountry(UpdateCountryDTO country)
        {
            var data = db.Country.FirstOrDefault(c => c.CountryId == country.CountryId && c.IsDeleted == 0 && c.IsActive == 1);
            if (data != null)
            {
                var updatedData = mapper.Map(country, data);
                db.Country.Update(updatedData);
                db.SaveChanges();
            }
        }

        public void DeleteCountry(int id)
        {
            var data = db.Country.FirstOrDefault(c => c.CountryId == id && c.IsDeleted == 0 && c.IsActive == 1);
            if (data != null)
            {
                data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                db.SaveChanges();
            }
        }

    }
}
