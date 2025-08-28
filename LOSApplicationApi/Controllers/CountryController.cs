using LOSApplicationApi.Data;
using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ApplicationDbContext db;
        ICountry country;
        public CountryController(ApplicationDbContext db, ICountry country)
        {
            this.db = db;
            this.country = country;
        }

        [HttpGet]
        [Route("FetchCountry")]
        public IActionResult FetchCountry()
        {
            var details = country.FetchCountry();

            return Ok(details);
        }

        [HttpPost]
        [Route("AddCountry")]
        public IActionResult AddCountry([FromBody] DTO.AddCountryDTO countryDTO)
        {
            country.AddCountry(countryDTO);
            return Ok("Country added successfully");
        }

        [HttpPut]
        [Route("UpdateCountry")]
        public IActionResult UpdateCountry([FromBody] DTO.UpdateCountryDTO countryDTO)
        {
            if (countryDTO == null || countryDTO.CountryId <= 0)
            {
                return BadRequest("Invalid country data.");
            }
            country.UpdateCountry(countryDTO);
            return Ok(new { message = "Country updated successfully" });
        }

        [HttpDelete]
        [Route("DeleteCountry/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid country ID.");
            }
            country.DeleteCountry(id);
            return Ok("Country deleted successfully");
        }

        [HttpGet]
        [Route("FetchCountryById/{id}")]
        public IActionResult FetchCountryById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid country ID.");
            }
            var countryData = country.FetchCountryById(id);
            if (countryData == null)
            {
                return NotFound("Country not found.");
            }
            return Ok(countryData);

        }
    }
}
