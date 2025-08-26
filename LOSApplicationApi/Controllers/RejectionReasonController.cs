using LOSApplicationApi.Data;
using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RejectionReasonController : ControllerBase
    {
        ApplicationDbContext db;
        IRejectionReason rejectionReason;
        public RejectionReasonController(ApplicationDbContext db, IRejectionReason rejectionReason)
        {
            this.db = db;
            this.rejectionReason = rejectionReason;
        }

        [HttpGet]
        [Route("FetchRejectionReason")]
        public IActionResult FetchRejectionReason()
        {
            var details = rejectionReason.FetchRejectionReasons();
            return Ok(details);
        }
        [HttpPost]
        [Route("AddRejectionReason")]
        public IActionResult AddRejectionReason([FromBody] DTO.AddRejectionReasonDTO rejectionReasonDTO)
        {
            rejectionReason.AddRejectionReason(rejectionReasonDTO);
            return Ok(new { message = "Rejection reason added successfully" });
        }

        [HttpPut]
        [Route("UpdateRejectionReason")]
        public IActionResult UpdateRejectionReason([FromBody] DTO.UpdateRejectionReasonDTO rejectionReasonDTO)
        {
            rejectionReason.UpdateRejectionReason(rejectionReasonDTO);
            return Ok(new { message = "Rejection reason updated successfully" });
        }

        [HttpDelete]
        [Route("DeleteRejectionReason/{id}")]
        public IActionResult DeleteRejectionReason(int id)
        {
            rejectionReason.DeleteRejectionReason(id);
            return Ok(new { message = "Rejection reason deleted successfully" });
        }

        [HttpGet]
        [Route("FetchRejectionReasonById/{id}")]
        public IActionResult FetchRejectionReasonById(int id)
        {
            var rejectionReasonData = rejectionReason.FetchRejectionReasonById(id);
            if (rejectionReasonData == null)
            {
                return NotFound(new { message = "Rejection reason not found" });
            }
            return Ok(rejectionReasonData);
        }
    }
}
