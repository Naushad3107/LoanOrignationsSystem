using AutoMapper;
using LOSApplicationApi.Data;
using Master.Application.Repository;
using Master.Domain.DTO.SubModuleDTOs;
using Master.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Infrastructure.Service
{
    public class SubModuleService : ISubModule
    {
        ApplicationDbContext db;
        IMapper mapper;
        public SubModuleService(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public void addsubmodule(AddSubModuleDTO subModule)
        {
               var submod = mapper.Map<SubModule>(subModule);
                db.subModules.Add(submod);
                db.SaveChanges();
        }

        public void deletesubmodule(int subModuleId)
        {
            bool ifreferenced = db.RolePermissions.Any(rp => rp.SubModuleId == subModuleId);

            if (ifreferenced)
            {
                throw new Exception("SubModule is referenced in RolePermissions, cannot delete.");
            }
            else
            {
                var submodule = db.subModules.FirstOrDefault(x => x.SubModuleId == subModuleId);
                if (submodule != null)
                {
                    submodule.IsDeleted = 1;
                }
                db.SaveChanges();
            }


        }

        public SubModule FetchSubModuleById(int id)
        {
                var data =  db.subModules.FirstOrDefault(x => x.SubModuleId == id && x.IsDeleted == 0 && x.IsActive == 1);
                var map = mapper.Map<SubModule>(data);
                return map;
        }

        public List<GetSubModuleDTO> getallsubmodules()
        {
            var data = db.subModules
                .Include(x => x.Module)
                .Where(x => x.IsDeleted == 0 && x.IsActive == 1)
                .ToList();   // 👈 Execute query

            var dtoList = mapper.Map<List<GetSubModuleDTO>>(data);
            return dtoList;
        }



        public void updatesubmodule(UpdateSubModuleDTO subModule)
        {
            var existingSubModule = db.subModules.FirstOrDefault(sm => sm.SubModuleId == subModule.SubModuleId && sm.IsDeleted == 0);
            if (existingSubModule != null)
            {
                existingSubModule.SubModuleName = subModule.SubModuleName;
                existingSubModule.Description = subModule.Description;
                existingSubModule.ModuleId = subModule.ModuleId;
                existingSubModule.IsActive = subModule.IsActive;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("SubModule not found or has been deleted.");
            }
        }

        
    }
}
