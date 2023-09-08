using Microsoft.AspNetCore.Mvc;
using Shirts.Models;

namespace Shirts.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt{ShirtId = 1 , Brand = "Levy" , Color = "Blue" , Gender = "Men" , Price = 99.95 , Size = 9},
            new Shirt{ShirtId = 2, Brand = "Gucci", Color = "Black", Gender = "Women", Price = 299.50 , Size = 6 },
            new Shirt{ShirtId = 3, Brand = "Nike", Color = "Orange", Gender ="Men" , Price = 59.98, Size = 8 }
        };

               
        
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
            var shirt =  shirts.FirstOrDefault(x => x.ShirtId == id);
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
