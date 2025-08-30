using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Model;
using LOSApplicationApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace LOSApplicationApi.Service
{
    public class PincodeServices: IPincode
    {
        ApplicationDbContext db;
        IMapper mapper;
        public PincodeServices(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void AddPincode(AddPincodeDTO pincode)
        {
            var details = mapper.Map<Pincode>(pincode);
            db.Pincode.Add(details);
            db.SaveChanges();
        }

        public void DeletePincode(int id)
        {
            var data = db.Pincode.FirstOrDefault(p => p.PincodeId == id);
            if (data != null)
            {
                data.IsDeleted = 1;
                db.SaveChanges();
            }
        }

        public FetchPincodeDTO FetchPincodeById(int id)
        {
            var data = db.Pincode.Include(c => c.City).Include(s => s.State).Include(c => c.Country).FirstOrDefault(p => p.PincodeId == id);
            var mappedData = mapper.Map<FetchPincodeDTO>(data);
            return mappedData;
        }

        public List<DTO.FetchPincodeDTO> FetchPincodes()
        {
            var details = db.Pincode.Include(x=>x.City).Include(x=>x.State).Include(x=>x.Country).Where(p => p.IsActive == 1 && p.IsDeleted == 0).ToList();
            var mappedDetails = mapper.Map<List<FetchPincodeDTO>>(details);
            return mappedDetails;
        }

        public void UpdatePincode(UpdatePincodeDTO pincode)
        {
            var data = db.Pincode.FirstOrDefault(p => p.PincodeId == pincode.PincodeId);
            mapper.Map(pincode, data);
            db.Pincode.Update(data);
            db.SaveChanges();
        }
    }
}
