using AutoMapper;
using Master.Application.Repository;
using Master.Domain.DTO.SubModuleDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubModuleController : ControllerBase
    {

        ISubModule service;

        public SubModuleController(ISubModule service) { 
        this.service = service;

        }

        [HttpGet]
        [Route("AllSubModules")]
        public IActionResult GetSubModule() {
        
            var data = service.getallsubmodules();
            return Ok(data);
        }


        [HttpPost]
        [Route("AddSubModules")]
        public IActionResult AddSubModule(AddSubModuleDTO module)
        {
            if (module == null) { 
                throw new ArgumentNullException(nameof(module));
            }
            else
            {

                service.addsubmodule(module);
                return Ok(new {message = "submodule added"});
            }
        }

        [HttpDelete]
        public IActionResult DeleteSubModule(int id) { 
        
            service.deletesubmodule(id);
            return Ok(new {message = " submodule deleted successfully"});
        }

        [HttpPut]
        public IActionResult UpdateSubmodule(UpdateSubModuleDTO module) { 
            service.updatesubmodule(module);

            return Ok(new { message = "submodule updated successfully" });
        }


    }
}
