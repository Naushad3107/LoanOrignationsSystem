using AutoMapper;
using LOSApplicationApi.Data;
using Master.Application.Repository;
using Master.Domain.DTO.ModuleDTOs;
using Master.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Infrastructure.Service
{
    public class ModuleService : IModule
    {
        ApplicationDbContext db;
        IMapper mapper;
        public ModuleService(ApplicationDbContext db,IMapper mapper)
        {
            this.mapper = mapper;
            this.db = db;
        }
        public void AddModule(AddModuleDTO module)
        {
            var data = mapper.Map<Module>(module);
            db.modules.Add(data);
            db.SaveChanges();
        }

        public void DeleteModule(int id)
        {
            db.modules.Where(x => x.IsDeleted == 1);
            db.SaveChanges();
        }



        public List<FetchModuleDTO> ViewModules()
        {
            var data = db.modules.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
            var mappedData = mapper.Map<List<FetchModuleDTO>>(data);
            return mappedData;
        }

        public Module FetchModuleById(int id)
        {
            var module = db.modules.FirstOrDefault(m => m.ModuleId == id);
            return module;
        }



    }
}
