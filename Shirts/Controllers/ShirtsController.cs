using Microsoft.AspNetCore.Mvc;

namespace Shirts.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class ShirtsController : ControllerBase
    {
        
        [HttpGet]
        public string GetShirts()
        {
            return "Get All the shirts from the e-shop";
        }
        
        [HttpGet("{id}")]
        public string GetShirts(int id)
        {
            return $"Get a shirt from the e-shop with id: {id}";
        }
        
        [HttpPost]
        public string PostShirts()
        {
            return "Post a shirt from the e-shop";
        }

        [HttpPut("{id}")]
        public string UpdateShirts(int id)
        {
            return $"Update a shirt from the e-shop with id: {id}";
        }

        [HttpDelete("{id}")]
        public string DeleteShirts(int id)
        {
            return $"Delete ashirts from the e-shop with id: {id}";
        }
    }
}
