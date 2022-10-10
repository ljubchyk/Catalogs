using Catalogs.Application;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductApplicationService productApplication;

        public ProductsController(ProductApplicationService productApplication)
        {
            this.productApplication = productApplication;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await productApplication.Get(id);
            return Ok(product);
        }
    }
}