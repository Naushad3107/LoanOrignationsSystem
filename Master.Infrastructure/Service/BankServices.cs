using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Model;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class BankServices : IBank
    {
        ApplicationDbContext db;
        IMapper mapper;
        public BankServices(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddBank(AddBankDTO b)
        {

            var details = mapper.Map<Bank>(b);
            db.Banks.Add(details);
            db.SaveChanges();

        }

        public List<FetchBankDTO> FetchBanks()
        {
            var data = db.Banks.Where(x=>x.IsActive==1&&x.IsDeleted==0).ToList();
            var details = mapper.Map<List<FetchBankDTO>>(data);
            return details;
        }

        public FetchBankDTO FetchBankById(int id)
        {
            var data = db.Banks.FirstOrDefault(b => b.BankId == id);
            var mapperData = mapper.Map<FetchBankDTO>(data);
            return mapperData;
        }

        public void UpdateBank(UpdateBankDTO b)
        {
            var data = db.Banks.Where(x=>x.IsDeleted==0&&x.IsActive==1).FirstOrDefault(b => b.BankId == b.BankId);
            var updateData = mapper.Map(b, data);
            db.Banks.Update(updateData);
            db.SaveChanges();
        }

        public void DeleteBank(int id)
        {
            var data = db.Banks.FirstOrDefault(b => b.BankId == id);
            if (data != null)
            {
                data.IsDeleted = 1;
                db.SaveChanges();
            }
        }
    }
}
