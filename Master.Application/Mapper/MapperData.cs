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
            CreateMap<Users, UpdateBankDTO>().ReverseMap();

            //Mapping configurations for Role
            CreateMap<Roles, AddRoleDTO>().ReverseMap();
            CreateMap<Roles, FetchRoleDTO>().ReverseMap();
            CreateMap<Roles, UpdateRoleDTO>().ReverseMap();

            //Mapping configurations for UserRoles
            CreateMap<UserRoles, AddUserRolesDTO>().ReverseMap();
            CreateMap<UserRoles, FetchUserRolesDTO>().ForMember(x=>x.UserName,x=>x.MapFrom(x=>x.User!=null?x.User.UserName:"No Data"))
                                               .ForMember(x=>x.RoleName,x=>x.MapFrom(x=>x.Role!=null?x.Role.RoleName:"No Data"));
            CreateMap<UserRoles, UpdateUserRolesDTO>().ReverseMap();

            //Mapping configurations for Countries
            CreateMap<Countries, AddCountryDTO>().ReverseMap();
            CreateMap<Countries, FetchCountryDTO>().ReverseMap();
            CreateMap<Countries, UpdateCountryDTO>().ReverseMap();

            //Mapping configurations for States
            CreateMap<States, AddStateDTO>().ReverseMap();
            CreateMap<States, FetchStateDTO>().ForMember(x=>x.CountryName,x=>x.MapFrom(x=>x.Country!=null?x.Country.CountryName:"No Data"));
            CreateMap<Countries, UpdateCountryDTO>().ReverseMap();

            //Mapping configurations for Cities
            CreateMap<Cities, AddCityDTO>().ReverseMap();
            CreateMap<Cities, FetchCityDTO>().ForMember(x => x.StateName, x => x.MapFrom(x => x.States != null ? x.States.StateName : "No Data"));
            CreateMap<Countries, UpdateCountryDTO>().ReverseMap();

            //Mapping configurations for Pincodes
            CreateMap<Pincode, AddPincodeDTO>().ReverseMap();
            CreateMap<Pincode, FetchPincodeDTO>().ForMember(x => x.StateName, x => x.MapFrom(x => x.State != null ? x.State.StateName : "No Data")).ForMember(x => x.CountryName, x => x.MapFrom(x => x.Country != null ? x.Country.CountryName : "No Data")).ForMember(x => x.CityName, x => x.MapFrom(x => x.City != null ? x.City.CityName : "No Data"));
            CreateMap<Pincode, UpdatePincodeDTO>().ReverseMap();

            //Mapping configurations for RejectionReasons
            CreateMap<RejectionReason, AddRejectionReasonDTO>().ReverseMap();
            CreateMap<RejectionReason, FetchRejectionReasonDTO>().ReverseMap();
            CreateMap<RejectionReason, UpdateRejectionReasonDTO>().ReverseMap();

            //Mapping configurations for EmploymentType
            CreateMap<EmploymentType, AddEmploymentTypeDTO>().ReverseMap();
            CreateMap<EmploymentType, FetchEmploymentTypeDTO>().ReverseMap();
            CreateMap<EmploymentType, UpdateEmployementTypeDTO>().ReverseMap();

            //Mapping configurations for Bank
            CreateMap<AddBankDTO, Bank>().ReverseMap();
            CreateMap<Bank, FetchBankDTO>().ReverseMap();
            CreateMap<Bank, UpdateBankDTO>().ReverseMap();

            //Mapping configurations for Occupation Type
            CreateMap<OccupationType, AddOccupationDTO>().ReverseMap();
            CreateMap<OccupationType, FetchOccupationDTO>().ReverseMap();
            CreateMap<OccupationType, UpdateOccupationDTO>().ReverseMap();

            //Mapping configurations for Document Type
            CreateMap<DocumentType, AddDocumentTypeDTO>().ReverseMap();
            CreateMap<DocumentType, FetchDocumentTypeDTO>().ReverseMap();
            CreateMap<DocumentType, UpdateDocumentTypeDTO>().ReverseMap();

            //Mapping configurations for Department
            CreateMap<Department, AddDepartmentDTO>().ReverseMap();
            CreateMap<Department, FetchDepartmentDTO>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDTO>().ReverseMap();

            //Mapping configurations for Branch
            CreateMap<Branch, AddBranchDTO>().ReverseMap();
            CreateMap<Branch, FetchBranchDTO>().ReverseMap();
            CreateMap<Branch, UpdateBranchDTO>().ReverseMap();


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
