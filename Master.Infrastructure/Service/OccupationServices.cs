using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Model;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class OccupationServices : IOccupation
    {
        ApplicationDbContext db;
        IMapper mapper;
        public OccupationServices(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public void AddOccupation(AddOccupationDTO occupation)
        {
            var details = mapper.Map<OccupationType>(occupation);
            db.OccupationTypes.Add(details);
            db.SaveChanges();
        }

        public List<FetchOccupationDTO> FetchOccupations()
        {
            var details = db.OccupationTypes.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
            var mappedDetails = mapper.Map<List<FetchOccupationDTO>>(details);
            return mappedDetails;
        }

        public FetchOccupationDTO FetchOccupationById(int id)
        {
            var data = db.OccupationTypes.Where(x => x.IsActive == 1 && x.IsDeleted == 0).FirstOrDefault(o => o.OccupationTypeId == id);
            if (data == null)
            {
                return null; // or throw an exception
            }
            var mappedData = mapper.Map<FetchOccupationDTO>(data);
            return mappedData;
        }

        public void UpdateOccupation(UpdateOccupationDTO occupation)
        {
            var data = db.OccupationTypes.FirstOrDefault(o => o.OccupationTypeId == occupation.OccupationTypeId && o.IsDeleted == 0 && o.IsActive == 1);
            if (data != null)
            {
                var updatedData = mapper.Map(occupation, data);
                db.OccupationTypes.Update(updatedData);
                db.SaveChanges();
            }
        }

        public void DeleteOccupation(int id)
        {
            var data = db.OccupationTypes.FirstOrDefault(o => o.OccupationTypeId == id && o.IsDeleted == 0 && o.IsActive == 1);
            if (data != null)
            {
                data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                db.SaveChanges();
            }
        }
    }
}
