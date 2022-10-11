using Catalogs.Application;
using Catalogs.Domain;
using Catalogs.Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Catalogs.Tests.ProductApplication
{
    public class CreateUnitTests
    {
        private readonly IProductRepository repo;
        private readonly UnitOfWorkFake uow;

        private readonly ProductApplicationService productApplication;

        public CreateUnitTests()
        {
            repo = new ProductRepositoryFake();
            uow = new UnitOfWorkFake();

            productApplication = new ProductApplicationService(repo, uow);
        }

        [Fact]
        public async Task Creates()
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
        public async Task InitializesArgument()
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

        [Fact]
        public async Task RaisesProductCreatedEvent()
        {
            var dbBuilder = new DbContextOptionsBuilder<Db>();
            dbBuilder.UseInMemoryDatabase("DbTest");
            var db = new Db(dbBuilder.Options);

            var repo = new ProductRepository(db);
            var bus = new BusFake();
            var uow = new UnitOfWork(db, bus);
            var productApplication = new ProductApplicationService(repo, uow);

            var product = new Application.Product
            {
                Cost = 1,
                Image = "im",
                Name = "n",
                Price = 2
            };

            await productApplication.Add(product);

            var sentEvent = bus.GetSentMessage<ProductCreated>();
            Assert.NotNull(sentEvent);
            Assert.Equal(product.Id, sentEvent.Id);
            Assert.Equal(product.Name, sentEvent.Name);
        }
    }
}