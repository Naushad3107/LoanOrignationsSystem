using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        ApplicationDbContext db;
        IBank bankService;
        public BankController(ApplicationDbContext db, IBank bankService)
        {
            this.db = db;
            this.bankService = bankService;
        }

        [HttpGet]
        [Route("FetchBanks")]
        public IActionResult FetchBanks()
        {
            var details = bankService.FetchBanks();
            return Ok(details);
        }

        [HttpPost]
        [Route("AddBank")]
        public IActionResult AddBank(AddBankDTO bankDTO)
        {
            bankService.AddBank(bankDTO);
            return Ok(new { message = "Bank added successfully" });
        }

        [HttpPut]
        [Route("UpdateBank")]
        public IActionResult UpdateBank(UpdateBankDTO bankDTO)
        {
            bankService.UpdateBank(bankDTO);
            return Ok(new { message = "Bank updated successfully" });
        }

        [HttpDelete]
        [Route("DeleteBank/{id}")]
        public IActionResult DeleteBank(int id)
        {
            bankService.DeleteBank(id);
            return Ok(new { message = "Bank deleted successfully" });
        }

        [HttpGet]
        [Route("FetchBankById/{id}")]
        public IActionResult FetchBankById(int id)
        {
            var bank = bankService.FetchBankById(id);
            if (bank == null)
            {
                return NotFound(new { message = "Bank not found" });
            }
            return Ok(bank);
        }
    }
}
