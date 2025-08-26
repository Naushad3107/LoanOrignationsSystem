using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ApplicationDbContext db;
        ICity cityService;

        public CityController(ApplicationDbContext db, ICity cityService)
        {
            this.db = db;
            this.cityService = cityService;
        }

        [HttpPost]
        [Route("AddCity")]
        public IActionResult AddCity(AddCityDTO city)
        {
            cityService.AddCity(city);
            return Ok(new { meassage = "City added successfully" });
        }

        [HttpGet]
        [Route("FetchCities")]
        public IActionResult FetchCities()
        {
            var mappedDetails = cityService.FetchCities();
            return Ok(mappedDetails);
        }

        [HttpGet]
        [Route("FetchCityById/{id}")]
        public IActionResult FetchCityById(int id)
        {
            var city = cityService.FetchCityById(id);
            if (city == null)
            {
                return NotFound(new { message = "City not found" });
            }
            return Ok(city);
        }

        [HttpPut]
        [Route("UpdateCity")]
        public IActionResult UpdateCity(UpdateCityDTO city)
        {
            cityService.UpdateCity(city);
            return Ok(new { message = "City updated successfully" });
        }
        [HttpDelete]
        [Route("DeleteCity/{id}")]
        public IActionResult DeleteCity(int id)
        {
            cityService.DeleteCity(id);
            return Ok(new { message = "City deleted successfully" });
        }
    }
}
