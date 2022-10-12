using Catalogs.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetProductQuery(id);
            var domainProduct = await mediator.Send(query);
            if (domainProduct is null)
            {
                return NotFound();
            }

            var product = new Product();
            Map(domainProduct, product);
            return Ok(product);
        }

        [HttpGet()]
        public async Task<IActionResult> GetList([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var query = new GetProductsQuery(offset, limit);
            var domainProducts = await mediator.Send(query);

            var products = domainProducts.Select(dp =>
            {
                var product = new Product();
                Map(dp, product);
                return product;
            }).ToArray();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            var command = new CreateProductCommand(
                product.Name,
                product.Price,
                product.Cost,
                product.Image);
            var domainProduct = await mediator.Send(command);

            Map(domainProduct, product);
            return CreatedAtAction(nameof(Get), new { product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Product product)
        {
            var command = new UpdateProductCommand(
                id,
                product.Name,
                product.Price,
                product.Cost,
                product.Image);
            var domainProduct = await mediator.Send(command);

            Map(domainProduct, product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveProductCommand(id);
            await mediator.Send(command);

            return Ok();
        }

        public static void Map(Domain.Product source, Product destination)
        {
            destination.Id = source.Id;
            destination.Image = source.Image;
            destination.Cost = source.Cost;
            destination.Name = source.Name;
            destination.Price = source.Price;
        }
    }
}