using Master.Application.Repository;
using Master.Domain.DTO.RolePermissionDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        IRolePermissions service;
        public RolePermissionController(IRolePermissions service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("AssignPermissionsToRole")]
        public IActionResult AssignPermissionsToRole(AddRolePermissionDTO rolepermission)
        {
            service.AssignPermissionsToRole(rolepermission);
            return Ok(new { message = "Permissions assigned to role successfully" });
        }

        [HttpPost]
        [Route("RemovePermissionsFromRole")]
        public IActionResult RemovePermissionsFromRole(RemoveRolePermissionDTO removerolepermission)
        {
            service.RemovePermissionsFromRole(removerolepermission);
            return Ok(new { message = "Permissions removed from role successfully" });
        }

        [HttpGet]
        [Route("GetPermissionsByRoleId/{roleId}")]
        public IActionResult GetPermissionsByRoleId(int roleId)
        {
            var permissions = service.GetPermissionsByRoleId(roleId);
            return Ok(permissions);
        }

        [HttpGet]
        [Route("GetRolePermissions")]
        public IActionResult GetRolePermissions()
        {
            var rolePermissions = service.GetRolePermissions();
            if (rolePermissions == null)
            {
                return NotFound(new { message = "No permissions found for the specified role" });
            }
            return Ok(rolePermissions);
        }
    }
}
