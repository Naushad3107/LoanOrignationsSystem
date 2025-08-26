using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class EmploymentTypeServices : IEmploymentType
    {
        ApplicationDbContext db;
        IMapper mapper;
        public EmploymentTypeServices(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void addEmploymentType(DTO.AddEmploymentTypeDTO employmentType)
        {
            var details = mapper.Map<Model.EmploymentType>(employmentType);
            db.EmploymentTypes.Add(details);
            db.SaveChanges();
        }

        public List<DTO.FetchEmploymentTypeDTO> FetchEmploymentTypes()
        {
            var details = db.EmploymentTypes.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
            var mappedDetails = mapper.Map<List<DTO.FetchEmploymentTypeDTO>>(details);
            return mappedDetails;
        }

        public DTO.FetchEmploymentTypeDTO FetchEmploymentTypeById(int id)
        {
            var data = db.EmploymentTypes.FirstOrDefault(x => x.IsActive == 1 && x.IsDeleted == 0 && x.EmployementTypeId == id);
            if (data != null)
            {
                var mappedData = mapper.Map<DTO.FetchEmploymentTypeDTO>(data);
                return mappedData;
            }
            return null; // or throw an exception if preferred
        }

        public void UpdateEmploymentType(DTO.UpdateEmployementTypeDTO employmentType)
        {
            var data = db.EmploymentTypes.FirstOrDefault(x => x.IsActive == 1 && x.IsDeleted == 0 && x.EmployementTypeId == employmentType.EmployementTypeId);
            if (data != null)
            {
                var updatedData = mapper.Map(employmentType, data);
                db.EmploymentTypes.Update(updatedData);
                db.SaveChanges();
            }
        }

        public void DeleteEmploymentType(int id)
        {
            var data = db.EmploymentTypes.FirstOrDefault(x => x.EmployementTypeId == id);
            if (data != null)
            {
                data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                db.SaveChanges();
            }
        }


    }
}
