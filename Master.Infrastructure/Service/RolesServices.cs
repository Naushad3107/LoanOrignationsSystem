using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class RolesServices:IRoles
    {
        IMapper mapper;
        ApplicationDbContext db;
        public RolesServices(ApplicationDbContext db, IMapper mapper) 
        { 
            this.db = db;
            this.mapper = mapper;
        }

        public void AddRole(AddRoleDTO role)
        {
            var details = mapper.Map<Model.Roles>(role);
            db.Role.Add(details);
            db.SaveChanges();
        }

        public List<FetchRoleDTO> FetchRoles()
        {
            var details = db.Role.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
            var mappedDetails = mapper.Map<List<FetchRoleDTO>>(details);
            return mappedDetails;
        }

        public FetchRoleDTO FetchRoleById(int id)
        {
            var data = db.Role.FirstOrDefault(r => r.RoleId == id && r.IsActive == 1 && r.IsDeleted == 0);
            if (data != null)
            {
                var mappedData = mapper.Map<FetchRoleDTO>(data);
                return mappedData;
            }
            return null; // or throw an exception if preferred
        }

        public void UpdateRole(UpdateRoleDTO role)
        {
            var data = db.Role.FirstOrDefault(r => r.RoleId == role.RoleId && r.IsActive == 1 && r.IsDeleted == 0);
            if (data != null)
            {
                var updatedData = mapper.Map(role, data);
                db.Role.Update(updatedData);
                db.SaveChanges();
            }
        }

        public void DeleteRole(int id)
        {

            bool ifreferenced = db.UserRole.Any(ur => ur.RoleId == id);
            if (!ifreferenced)
            {
                var data = db.Role.FirstOrDefault(r => r.RoleId == id && r.IsActive == 1 && r.IsDeleted == 0);
                if (data != null)
                {
                    data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                    db.SaveChanges();
                }
            }

        }

    }
}
