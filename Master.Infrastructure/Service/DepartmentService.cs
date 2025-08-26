using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.Model;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class DepartmentService : IDepartment
    {
        ApplicationDbContext db;
        IMapper mapper;
        public DepartmentService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddDepartment(DTO.AddDepartmentDTO department)
        {
            var details = mapper.Map<Department>(department);
            db.Departments.Add(details);
            db.SaveChanges();
        }

        public List<DTO.FetchDepartmentDTO> FetchDepartments()
        {
            var details = db.Departments.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
            var mappedDetails = mapper.Map<List<DTO.FetchDepartmentDTO>>(details);
            return mappedDetails;


        }

        public DTO.FetchDepartmentDTO FetchDepartmentById(int id)
        {
            var data = db.Departments.Where(x => x.IsActive == 1 && x.IsDeleted == 0).FirstOrDefault(d => d.DepartmentId == id);
            if (data != null)
            {
                var mappedData = mapper.Map<DTO.FetchDepartmentDTO>(data);
                return mappedData;
            }
            return null; // or throw an exception if preferred
        }

        public void UpdateDepartment(DTO.UpdateDepartmentDTO department)
        {
            var data = db.Departments.FirstOrDefault(d => d.DepartmentId == department.DepartmentId && d.IsDeleted == 0 && d.IsActive == 1);
            if (data != null)
            {
                var updatedData = mapper.Map(department, data);
                db.Departments.Update(updatedData);
                db.SaveChanges();
            }
        }

        public void DeleteDepartment(int id)
        {
            var data = db.Departments.FirstOrDefault(d => d.DepartmentId == id && d.IsDeleted == 0 && d.IsActive == 1);
            if (data != null)
            {
                data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                db.SaveChanges();
            }
        }
    }
}
