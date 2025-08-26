using LOSApplicationApi.Data;
using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        ApplicationDbContext db;
        IDepartment departmentService;

        public DepartmentController(ApplicationDbContext db, IDepartment departmentService)
        {
            this.db = db;
            this.departmentService = departmentService;
        }

        [HttpGet]
        [Route("FetchDepartments")]
        public IActionResult FetchDepartments()
        {
            var details = departmentService.FetchDepartments();
            return Ok(details);
        }

        [HttpPost]
        [Route("AddDepartment")]
        public IActionResult AddDepartment([FromBody] DTO.AddDepartmentDTO departmentDTO)
        {
            departmentService.AddDepartment(departmentDTO);
            return Ok(new { message = "Department added successfully" });

        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public IActionResult UpdateDepartment([FromBody] DTO.UpdateDepartmentDTO departmentDTO)
        {
            departmentService.UpdateDepartment(departmentDTO);
            return Ok(new { message = "Department updated successfully" });
        }

        [HttpDelete]
        [Route("DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            departmentService.DeleteDepartment(id);
            return Ok(new { message = "Department deleted successfully" });
        }

        [HttpGet]
        [Route("FetchDepartmentById/{id}")]
        public IActionResult FetchDepartmentById(int id)
        {
            var department = departmentService.FetchDepartmentById(id);
            if (department == null)
            {
                return NotFound(new { message = "Department not found" });
            }
            return Ok(department);
        }
    }
}
