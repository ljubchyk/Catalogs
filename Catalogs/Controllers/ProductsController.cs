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
            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet()]
        public async Task<IActionResult> GetList([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var products = await productApplication.GetList(offset, limit);

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            await productApplication.Add(product);
            
            return CreatedAtAction(nameof(Get), new { product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Product product)
        {
            await productApplication.Update(id, product);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await productApplication.Remove(id);

            return Ok();
        }
    }
}