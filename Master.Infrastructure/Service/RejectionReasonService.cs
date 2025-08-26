using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Model;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class RejectionReasonService: IRejectionReason
    {
        ApplicationDbContext db;
        IMapper mapper;
        public RejectionReasonService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddRejectionReason(AddRejectionReasonDTO rejectionReason)
        {
            var details = mapper.Map<RejectionReason>(rejectionReason);
            db.ReajectionReasons.Add(details);
            db.SaveChanges();
        }

        public List<FetchRejectionReasonDTO> FetchRejectionReasons()
        {
            var details = db.ReajectionReasons.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
            var mappedDetails = mapper.Map<List<FetchRejectionReasonDTO>>(details);
            return mappedDetails;
        }

        public FetchRejectionReasonDTO FetchRejectionReasonById(int id)
        {
            var data = db.ReajectionReasons.Where(x => x.IsActive == 1 && x.IsDeleted == 0).FirstOrDefault(b => b.ReasonId == id);
            var mappedData = mapper.Map<FetchRejectionReasonDTO>(data);
            return mappedData;
        }

        public void UpdateRejectionReason(UpdateRejectionReasonDTO rejectionReason)
        {
            var data = db.ReajectionReasons.FirstOrDefault(b => b.ReasonId == rejectionReason.ReasonId);
            if (data != null)
            {
                var updatedData = mapper.Map(rejectionReason, data);
                db.ReajectionReasons.Update(updatedData);
                db.SaveChanges();
            }
        }

        public void DeleteRejectionReason(int id)
        {
            var data = db.ReajectionReasons.FirstOrDefault(b => b.ReasonId == id);
            if (data != null)
            {
                data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                db.SaveChanges();
            }
        }
    }
}
