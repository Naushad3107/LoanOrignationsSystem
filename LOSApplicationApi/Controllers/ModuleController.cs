using Master.Application.Repository;
using Master.Domain.DTO.ModuleDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        IModule service;
        public ModuleController(IModule service)
        {
            this.service = service;
        }

        [HttpGet("ViewModules")]
        public IActionResult ViewModules()
        {
            var data = service.ViewModules();
            return Ok(data);
        }

        [HttpPost("AddModule")]
        public IActionResult AddModule(AddModuleDTO module)
        {
            service.AddModule(module);
            return Ok("Module Added Successfully");
        }

        [HttpDelete("id")]
        public IActionResult DeleteModule(int id)
        { 
            service?.DeleteModule(id);
            return Ok(new {message = "Module Deleted Sucessfully"});
        }
    }
}
