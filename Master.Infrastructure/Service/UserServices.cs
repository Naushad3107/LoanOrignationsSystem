using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Model;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class UserServices : IUser
    {
        ApplicationDbContext db;
        IMapper mapper;
        public UserServices(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddUser(AddUserDTO user)
        {
            var details = mapper.Map<Users>(user);
            db.User.Add(details);
            db.SaveChanges();

        }

        public List<FetchUserDTO> FetchUsers()
        {
            var details = db.User.ToList();
            var mappedDetails = mapper.Map<List<FetchUserDTO>>(details);
            return mappedDetails;
        }

        public Users FetchUsersById(int id)
        {
            var user = db.User.FirstOrDefault(u => u.UserId == id);
            return user;
        }

        public void UpdateUser(FetchUserDTO user)
        {
            var details = db.User.FirstOrDefault(u => u.UserId == user.UserId);
            var data = mapper.Map<Users>(details);
            db.User.Update(data);
        }

        public void DeleteUser(int id)
        {
            var user = db.User.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                user.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion

                db.SaveChanges();
            }
        }
    }
}
