using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        IRoles role;
        public RolesController(IRoles role)
        {
            this.role = role;
        }

        [HttpGet]
        [Route("FetchRoles")]
        public IActionResult FetchRoles()
        {
            var data = role.FetchRoles();
            return Ok(data);
        }

        [HttpPost]
        [Route("AddRole")]
        public IActionResult AddRole(DTO.AddRoleDTO addRole)
        {
            role.AddRole(addRole);
            return Ok(new { message = "Role added successfully" });
        }

        [HttpPut]
        [Route("UpdateRole")]
        public IActionResult UpdateRole(DTO.UpdateRoleDTO updateRole)
        {
            role.UpdateRole(updateRole);
            return Ok(new { message = "Role updated successfully" });
        }

        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public IActionResult DeleteRole(int id)
        {
            role.DeleteRole(id);
            return Ok(new { message = "Role deleted successfully" });
        }

        [HttpGet]
        [Route("FetchRoleById/{id}")]
        public IActionResult FetchRoleById(int id)
        {
            var data = role.FetchRoleById(id);
            if (data == null)
            {
                return NotFound(new { message = "Role not found" });
            }
            return Ok(data);
        }
    }
}
