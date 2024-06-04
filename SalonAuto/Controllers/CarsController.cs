using Microsoft.AspNetCore.Mvc;

namespace AutoSalon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCars()
        {
            return Ok(new List<string> { "Car1", "Car2" });
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody] string car)
        {
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] string car)
        {
            return Ok(car);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            return NoContent();
        }
    }
}
