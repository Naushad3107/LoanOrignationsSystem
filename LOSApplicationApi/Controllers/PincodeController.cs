using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PincodeController : ControllerBase
    {
        ApplicationDbContext db;
        IPincode pincodeService;
        public PincodeController(ApplicationDbContext db, IPincode pincodeService)
        {
            this.db = db;
            this.pincodeService = pincodeService;
        }

        [HttpGet]
        [Route("FetchPincode")]
        public IActionResult FetchPincode()
        {
            var details = pincodeService.FetchPincodes();
            return Ok(details);
        }

        [HttpPost]
        [Route("AddPincode")]
        public IActionResult AddPincode([FromBody] DTO.AddPincodeDTO pincodeDTO)
        {
            pincodeService.AddPincode(pincodeDTO);
            return Ok(new { message = "Pincode added successfully" });
        }

        [HttpPut]
        [Route("UpdatePincode")]
        public IActionResult UpdatePincode([FromBody] UpdatePincodeDTO pincodeDTO)
        {
            pincodeService.UpdatePincode(pincodeDTO);
            return Ok(new { message = "Pincode updated successfully" });
        }

        [HttpGet]
        [Route("FetchPincodeById/{id}")]
        public IActionResult FetchPincodeById(int id)
        {
            var pincodeDetails = pincodeService.FetchPincodeById(id);
            return Ok(pincodeDetails);
        }

        [HttpDelete]
        [Route("DeletePincode/{id}")]
        public IActionResult DeletePincode(int id)
        {
            var pincode = db.Pincode.FirstOrDefault(p => p.PincodeId == id);
            pincodeService.DeletePincode(id);
            return Ok(new { message = "Pincode deleted successfully" });
        }
    }
}
