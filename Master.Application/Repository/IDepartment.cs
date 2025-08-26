using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IDepartment
    {
        void AddDepartment(AddDepartmentDTO department);
        List<FetchDepartmentDTO> FetchDepartments();
        FetchDepartmentDTO FetchDepartmentById(int id);
        void UpdateDepartment(UpdateDepartmentDTO department);
        void DeleteDepartment(int id);
    }
}
