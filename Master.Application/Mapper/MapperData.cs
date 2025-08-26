using AutoMapper;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Model;
using Master.Domain.DTO.ModuleDTOs;
using Master.Domain.Model;

namespace LOSApplicationApi.Mapper
{
    public class MapperData: Profile
    {
        public MapperData()
        {
            //Mapping configurations for User
            CreateMap<Users,AddUserDTO>().ReverseMap();
            CreateMap<Users,FetchUserDTO>().ReverseMap();

            //Mapping configurations for Role
            CreateMap<Roles, AddRoleDTO>().ReverseMap();
            CreateMap<Roles, FetchRoleDTO>().ReverseMap();

            //Mapping configurations for UserRoles
            CreateMap<UserRoles, AddUserRolesDTO>().ReverseMap();
            CreateMap<UserRoles, FetchUserRolesDTO>().ReverseMap();

            //Mapping configurations for Countries
            CreateMap<Countries, AddCountryDTO>().ReverseMap();
            CreateMap<Countries, FetchCountryDTO>().ReverseMap();

            //Mapping configurations for States
            CreateMap<States, AddStateDTO>().ReverseMap();
            CreateMap<States, FetchStateDTO>().ReverseMap();

            //Mapping configurations for Cities
            CreateMap<Cities, AddCityDTO>().ReverseMap();
            CreateMap<Cities, FetchCityDTO>().ReverseMap();

            //Mapping configurations for Pincodes
            CreateMap<Pincode, AddPincodeDTO>().ReverseMap();
            CreateMap<Pincode, FetchPincodeDTO>().ReverseMap();
            CreateMap<Pincode, UpdatePincodeDTO>().ReverseMap();

            //Mapping configurations for RejectionReasons
            CreateMap<RejectionReason, AddRejectionReasonDTO>().ReverseMap();
            CreateMap<RejectionReason, FetchRejectionReasonDTO>().ReverseMap();

            //Mapping configurations for EmploymentType
            CreateMap<EmploymentType, AddEmploymentTypeDTO>().ReverseMap();
            CreateMap<EmploymentType, FetchEmploymentTypeDTO>().ReverseMap();

            //Mapping configurations for Bank
            CreateMap<AddBankDTO, Bank>().ReverseMap();
            CreateMap<Bank, FetchBankDTO>().ReverseMap();

            //Mapping configurations for Occupation Type
            CreateMap<OccupationType, AddOccupationDTO>().ReverseMap();
            CreateMap<OccupationType, FetchOccupationDTO>().ReverseMap();

            //Mapping configurations for Document Type
            CreateMap<DocumentType, AddDocumentTypeDTO>().ReverseMap();
            CreateMap<DocumentType, FetchDocumentTypeDTO>().ReverseMap();

            //Mapping configurations for Department
            CreateMap<Department, AddDepartmentDTO>().ReverseMap();
            CreateMap<Department, FetchDepartmentDTO>().ReverseMap();

            //Mapping configurations for Branch
            CreateMap<Branch, AddBranchDTO>().ReverseMap();
            CreateMap<Branch, FetchBranchDTO>().ReverseMap();


            //mapping for modules
            CreateMap<Module,AddModuleDTO>().ReverseMap();
            CreateMap<Module,FetchModuleDTO>().ReverseMap();

        }

    }
}
