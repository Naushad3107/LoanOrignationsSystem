using LOSApplicationApi.Data;
using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        IUserRoles userRoles;
        ApplicationDbContext db;
        public UserRolesController(IUserRoles userRoles, ApplicationDbContext db)
        {
            this.userRoles = userRoles;
            this.db = db;
        }

        [HttpGet]
        [Route("FetchUserRoles")]
        public IActionResult FetchUserRoles()
        {
            var data = userRoles.FetchUserRoles();
            if (data == null || !data.Any())
            {
                return NotFound(new { message = "No user roles found" });
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("AddUserRole")]
        public IActionResult AddUserRole(DTO.AddUserRolesDTO addUserRole)
        {
            if (addUserRole == null)
            {
                return BadRequest(new { message = "Invalid user role data" });
            }
            // Check if the user exists
            var userExists = db.User.Any(u => u.UserId == addUserRole.UserId);
            if (!userExists)
            {
                return NotFound(new { message = "User not found" });
            }
            // Check if the role exists
            var roleExists = db.Role.Any(r => r.RoleId == addUserRole.RoleId);
            if (!roleExists)
            {
                return NotFound(new { message = "Role not found" });
            }
            userRoles.AddUserRole(addUserRole);
            return Ok(new { message = "User role added successfully" });
        }

        [HttpPut]
        [Route("UpdateUserRole")]
        public IActionResult UpdateUserRole(DTO.UpdateUserRolesDTO updateUserRole)
        {
            if (updateUserRole == null)
            {
                return BadRequest(new { message = "Invalid user role data" });
            }
            // Check if the user exists
            var userExists = db.User.Any(u => u.UserId == updateUserRole.UserId);
            if (!userExists)
            {
                return NotFound(new { message = "User not found" });
            }
            // Check if the role exists
            var roleExists = db.Role.Any(r => r.RoleId == updateUserRole.RoleId);
            if (!roleExists)
            {
                return NotFound(new { message = "Role not found" });
            }
            userRoles.UpdateUserRole(updateUserRole);
            return Ok(new { message = "User role updated successfully" });
        }

        [HttpDelete]

        [Route("DeleteUserRole/{id}")]
        public IActionResult DeleteUserRole(int id)
        {
            var userRole = userRoles.FetchUserRoleById(id);
            if (userRole == null)
            {
                return NotFound(new { message = "User role not found" });
            }
            userRoles.DeleteUserRole(id);
            return Ok(new { message = "User role deleted successfully" });
        }

        [HttpGet]
        [Route("FetchUserRoleById/{id}")]
        public IActionResult FetchUserRoleById(int id)
        {
            var userRole = userRoles.FetchUserRoleById(id);
            if (userRole == null)
            {
                return NotFound(new { message = "User role not found" });
            }
            return Ok(userRole);
        }
    }
}
