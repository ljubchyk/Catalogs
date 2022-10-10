using Microsoft.AspNetCore.Mvc;

namespace Catalogs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
            
        }

        [HttpGet("{id}")]
        public Task<IActionResult> Get(Guid id)
        {

        }
    }
}