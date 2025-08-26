using LOSApplicationApi.Data;
using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        ApplicationDbContext db;
        IStates stateService;
        public StateController(ApplicationDbContext db, IStates stateService)
        {
            this.db = db;
            this.stateService = stateService;
        }

        [HttpGet]
        [Route("FetchStates")]
        public IActionResult FetchStates()
        {
            var details = stateService.FetchStates();
            return Ok(details);
        }

        [HttpPost]
        [Route("AddState")]
        public IActionResult AddState([FromBody] DTO.AddStateDTO stateDTO)
        {
            stateService.AddState(stateDTO);
            return Ok(new { message = "State added successfully" });
        }

        [HttpPut]
        [Route("UpdateState")]
        public IActionResult UpdateState([FromBody] DTO.UpdateStatesDTO stateDTO)
        {
            stateService.UpdateState(stateDTO);
            return Ok(new { message = "State updated successfully" });
        }

        [HttpDelete]
        [Route("DeleteState/{id}")]
        public IActionResult DeleteState(int id)
        {
            stateService.DeleteState(id);
            return Ok(new { message = "State deleted successfully" });
        }

        [HttpGet]
        [Route("FetchStateById/{id}")]
        public IActionResult FetchStateById(int id)
        {
            var state = stateService.FetchStateById(id);
            if (state == null)
            {
                return NotFound(new { message = "State not found" });
            }
            return Ok(state);
        }
    }
}
