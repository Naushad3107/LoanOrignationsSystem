using Master.Domain.DTO.SubModuleDTOs;
using Master.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Application.Repository
{
    public interface ISubModule
    {
        void addsubmodule(AddSubModuleDTO subModule);

        void updatesubmodule(UpdateSubModuleDTO subModule);

        void deletesubmodule(int subModuleId);

        List<GetSubModuleDTO> getallsubmodules();

        SubModule FetchSubModuleById(int id);
    }
}
