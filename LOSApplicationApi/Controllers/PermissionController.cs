using Master.Application.Repository;
using Master.Domain.DTO.PermissionDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        IPermission permissionService;
        public PermissionController(IPermission permissionService)
        {
            this.permissionService = permissionService;
        }

        [HttpGet]
        [Route("ViewPermissions")]
        public IActionResult ViewPermissions()
        {
            var details = permissionService.ViewPermissions();
            return Ok(details);
        }

        [HttpPost]
        [Route("AddPermission")]
        public IActionResult AddPermission(AddPermissionDTO permissionDTO)
        {
            permissionService.AddPermission(permissionDTO);
            return Ok(new { message = "Permission added successfully" });
        }

        [HttpDelete]
        [Route("DeletePermission/{id}")]
        public IActionResult DeletePermission(int id)
        {
            try
            {
                permissionService.DeletePermission(id);
                return Ok(new { message = "Permission deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("FetchPermissionById/{id}")]
        public IActionResult FetchPermissionById(int id)
        {
            var permission = permissionService.FetchPermissionById(id);
            if (permission == null)
            {
                return NotFound(new { message = "Permission not found" });
            }
            return Ok(permission);
        }


    }
}
