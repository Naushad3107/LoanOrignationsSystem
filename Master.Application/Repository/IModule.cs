using Master.Domain.DTO.ModuleDTOs;
using Master.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Application.Repository
{
    public interface IModule
    {
        void AddModule(AddModuleDTO module);

        List<FetchModuleDTO> ViewModules();

        void DeleteModule(int id);

        Module FetchModuleById(int id);
    }
}
