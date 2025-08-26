using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IUserRoles
    {
        void AddUserRole(AddUserRolesDTO userRole);
        List<FetchUserRolesDTO> FetchUserRoles();
        FetchUserRolesDTO FetchUserRoleById(int id);
        void UpdateUserRole(UpdateUserRolesDTO userRole);
        void DeleteUserRole(int id);

    }
}
