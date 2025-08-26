using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.Model;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class BranchServices : IBranch
    {
        ApplicationDbContext db;
        IMapper mapper;
        public BranchServices(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddBranch(DTO.AddBranchDTO branch)
        {
            var details = mapper.Map<Branch>(branch);
            db.Branches.Add(details);
            db.SaveChanges();
        }

        public List<DTO.FetchBranchDTO> FetchBranches()
        {
            var details = db.Branches.Where(x=>x.IsActive==1&&x.IsDeleted==0).ToList();
            var mappedDetails = mapper.Map<List<DTO.FetchBranchDTO>>(details);
            return mappedDetails;

        }

        public DTO.FetchBranchDTO FetchBranchById(int id)
        {
            var data = db.Branches.Where(x => x.IsActive == 1 && x.IsDeleted == 0).FirstOrDefault(b => b.BranchId == id);
            var mappedData = mapper.Map<DTO.FetchBranchDTO>(data);
            return mappedData;
        }
        public void UpdateBranch(DTO.UpdateBranchDTO branch)
        {
            var data = db.Branches.FirstOrDefault(b => b.BranchId == branch.BranchId);
            if (data != null)
            {
                var updatedData = mapper.Map(branch, data);
                db.Branches.Update(updatedData);
                db.SaveChanges();
            }
        }
        public void DeleteBranch(int id)
        {
            var data = db.Branches.FirstOrDefault(b => b.BranchId == id);
            if (data != null)
            {
                data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                db.SaveChanges();
            }
        }

    }
}
