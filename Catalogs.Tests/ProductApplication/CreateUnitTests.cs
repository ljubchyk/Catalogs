using Catalogs.Application;
using Catalogs.Domain;
using Catalogs.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Catalogs.Tests.ProductApplication
{
    public class CreateUnitTests
    {
        private readonly ProductRepositoryFake repo;
        private readonly UnitOfWorkFake uow;

        private readonly ProductApplicationService productApplication;

        public CreateUnitTests()
        {
            repo = new ProductRepositoryFake();
            uow = new UnitOfWorkFake();

            productApplication = new ProductApplicationService(repo, uow);
        }

        [Fact]
        public async Task Create_Creates()
        {
            var product = new Application.Product
            {
                Cost = 1,
                Image = "im",
                Name = "n",
                Price = 2
            };

            await productApplication.Add(product);
            Assert.True(uow.IsCommited);

            var domainProducts = await repo.GetList(0, 1);
            Assert.NotNull(domainProducts);

            var domainProduct = domainProducts.FirstOrDefault();
            Assert.NotNull(domainProduct);
            Assert.Equal(product.Cost, domainProduct.Cost);
            Assert.Equal(product.Image, domainProduct.Image);
            Assert.Equal(product.Name, domainProduct.Name);
            Assert.Equal(product.Price, domainProduct.Price);
        }

        [Fact]
        public async Task Create_InitializeArgument()
        {
            var product = new Application.Product
            {
                Cost = 1,
                Image = "im",
                Name = "n",
                Price = 2
            };

            await productApplication.Add(product);

            Assert.NotNull(product);
            Assert.NotEqual(Guid.Empty, product.Id);
            Assert.Equal(1, product.Cost);
            Assert.Equal("im", product.Image);
            Assert.Equal("n", product.Name);
            Assert.Equal(2, product.Price);
        }
    }
}