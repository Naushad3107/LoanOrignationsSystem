using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IEmploymentType
    {
        void addEmploymentType(AddEmploymentTypeDTO employmentType);
        List<FetchEmploymentTypeDTO> FetchEmploymentTypes();
        FetchEmploymentTypeDTO FetchEmploymentTypeById(int id);
        void UpdateEmploymentType(UpdateEmployementTypeDTO employmentType);
        void DeleteEmploymentType(int id);
    }
}
