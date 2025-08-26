using LOSApplicationApi.DTO;
using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser user;
        public UserController(IUser user)
        {
            this.user = user;
        }

        [HttpGet]
        [Route("FetchUser")]
        public IActionResult FetchUser()
        {
            var data = user.FetchUsers();
            return Ok(data);
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(AddUserDTO addUser)
        {
            user.AddUser(addUser);
            return Ok(new { message = "User added successfully" });

        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(FetchUserDTO userDetails)
        {
            user.UpdateUser(userDetails);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpGet]
        [Route("FetchUserById/{id}")]
        public IActionResult FetchUserById(int id)
        {
            var userDetails = user.FetchUsersById(id);
            if (userDetails == null)
            {
                return NotFound(new { message = "User not found" });
            }
            return Ok(userDetails);

        }

        [HttpDelete]    
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var userDetails = user.FetchUsersById(id);
            if (userDetails == null)
            {
                return NotFound(new { message = "User not found" });
            }
            user.DeleteUser(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
