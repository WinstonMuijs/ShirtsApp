using Microsoft.AspNetCore.Mvc;
using Shirts.Models;
using Shirts.Models.Repositories;

namespace Shirts.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok("Get All the shirts from the e-shop");
        }
        
        [HttpGet("{id}")]
        public IActionResult GetShirts(int id)
        {
            if(id < 0)
            {
                return BadRequest();
            }
            var shirt = ShirtRepository.GetShirtById(id);
            if(shirt == null)
            {
                return NotFound();
            }
            return Ok(shirt);
        }
        
        [HttpPost]
        public IActionResult CreateShirts([FromBody] Shirt shirt)
        {
            return Ok("Post a shirt from the e-shop");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShirts(int id)
        {
            return Ok($"Update a shirt from the e-shop with id: {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirts(int id)
        {
            return Ok($"Delete ashirts from the e-shop with id: {id}");
        }
    }
}
