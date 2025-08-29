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
            bool ifreferenced = db.subModules.Any(sb => sb.ModuleId == id);
            if(ifreferenced)
            {
                throw new Exception("Module is referenced in SubModule, cannot delete.");
            }
            else
            {
                var user = db.modules.FirstOrDefault(x => x.ModuleId == id);

                if (user != null)
                {
                    user.IsDeleted = 1;
                }
                db.SaveChanges();
            }
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

        public void UpdateModule(UpdateModuleDTO module)
        {
            var details = db.modules.FirstOrDefault(m => m.ModuleId == module.ModuleId);
            var data = mapper.Map<Module>(details);
            db.modules.Update(data);
            db.SaveChanges();
        }





    }
}
