using AutoMapper;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Model;
using Master.Application.Repository;
using Master.Domain.DTO.ModuleDTOs;
using Master.Domain.DTO.PermissionDTOs;
using Master.Domain.DTO.RolePermissionDTOs;
using Master.Domain.DTO.SubModuleDTOs;
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
            CreateMap<Module, UpdateModuleDTO>().ReverseMap();


            //mapping for submodules
            CreateMap<SubModule, AddSubModuleDTO>().ReverseMap();
            CreateMap<SubModule, GetSubModuleDTO>()
                .ForMember(dest => dest.ModuleName, opt => opt.MapFrom(src => src.Module.ModuleName));
            CreateMap<SubModule, UpdateSubModuleDTO>().ReverseMap();

            //mapping for permissions
            CreateMap<Permissions, AddPermissionDTO>().ReverseMap();
            CreateMap<Permissions, FetchPermissionDTO>().ReverseMap();
            CreateMap<Permissions, UpdatePermissionDTO>().ReverseMap();

            //mapping for rolepermissions
            CreateMap<AddRolePermissionDTO, RolePermissions>()
                    .ForMember(dest => dest.PermissionId, opt => opt.Ignore());


            CreateMap<RolePermissions, FetchRolePermissionsDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
                .ForMember(dest => dest.PermissionNames, opt => opt.MapFrom(src => src.Permission.PermissionName))
                .ForMember(dest => dest.SubModuleNames, opt => opt.MapFrom(src => src.SubModule.SubModuleName));
        }

    }
}
