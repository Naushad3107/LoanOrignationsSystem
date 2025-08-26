using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class UserRolesService : IUserRoles
    {
        ApplicationDbContext db;
        IMapper mapper;
        public UserRolesService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddUserRole(AddUserRolesDTO userRole)
        {
            var details = mapper.Map<Model.UserRoles>(userRole);
            db.UserRole.Add(details);
            db.SaveChanges();
        }

        public List<FetchUserRolesDTO> FetchUserRoles()
        {
            var details = db.UserRole.Where(x => x.IsDeleted == 0).ToList();
            var mappedDetails = mapper.Map<List<FetchUserRolesDTO>>(details);
            return mappedDetails;
        }

        public FetchUserRolesDTO FetchUserRoleById(int id)
        {
            var data = db.UserRole.FirstOrDefault(x => x.UserRoleId == id && x.IsDeleted == 0);
            if (data != null)
            {
                var mappedData = mapper.Map<FetchUserRolesDTO>(data);
                return mappedData;
            }
            return null; // or throw an exception if preferred
        }

        public void UpdateUserRole(UpdateUserRolesDTO userRole)
        {
            var data = db.UserRole.FirstOrDefault(x => x.UserRoleId == userRole.UserRoleId && x.IsDeleted == 0);
            if (data != null)
            {
                var updatedData = mapper.Map(userRole, data);
                db.UserRole.Update(updatedData);
                db.SaveChanges();
            }
        }

        public void DeleteUserRole(int id)
        {
            var data = db.UserRole.FirstOrDefault(x => x.UserRoleId == id && x.IsDeleted == 0);
            if (data != null)
            {
                data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                db.SaveChanges();
            }
        }
    }
}
