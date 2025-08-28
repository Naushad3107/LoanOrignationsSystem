using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Model;
using LOSApplicationApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace LOSApplicationApi.Service
{
    public class CityServices: ICity
    {
        ApplicationDbContext db;
        IMapper mapper;
        public CityServices(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddCity(AddCityDTO city)
        {
            var details = mapper.Map<Cities>(city);
            db.City.Add(details);
            db.SaveChanges();
        }

        public List<DTO.FetchCityDTO> FetchCities()
        {
            var details = db.City.Where(x => x.IsActive == 1 && x.IsDeleted == 0).Include(x=>x.States).ToList();
            var mappedDetails = mapper.Map<List<FetchCityDTO>>(details);
            return mappedDetails;
        }

        public FetchCityDTO FetchCityById(int id)
        {
            var data = db.City.Where(x => x.IsActive == 1 && x.IsDeleted == 0).FirstOrDefault(c => c.CityId == id);
            var mappedData = mapper.Map<FetchCityDTO>(data);
            return mappedData;
        }

        public void UpdateCity(UpdateCityDTO city)
        {
            var data = db.City.FirstOrDefault(c => c.CityId == city.CityId);
            if (data != null)
            {
                var updatedData = mapper.Map(city, data);
                db.City.Update(updatedData);
                db.SaveChanges();
            }
        }

        public void DeleteCity(int id)
        {
            var data = db.City.FirstOrDefault(c => c.CityId == id);
            if (data != null)
            {
                data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                db.SaveChanges();
            }
        }

    }
}
