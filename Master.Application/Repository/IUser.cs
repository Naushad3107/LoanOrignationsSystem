using LOSApplicationApi.DTO;
using LOSApplicationApi.Model;

namespace LOSApplicationApi.Repository
{
    public interface IUser
    {
        void AddUser(AddUserDTO user);
        List<FetchUserDTO> FetchUsers();
        void UpdateUser(FetchUserDTO user);
        Users FetchUsersById(int id);
        void DeleteUser(int id);
    }
}
