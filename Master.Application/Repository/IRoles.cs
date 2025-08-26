using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IRoles
    {
        void AddRole(AddRoleDTO role);
        List<FetchRoleDTO> FetchRoles();
        FetchRoleDTO FetchRoleById(int id);
        void UpdateRole(UpdateRoleDTO role);
        void DeleteRole(int id);
    }
}
