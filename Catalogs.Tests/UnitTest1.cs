using Catalogs.Domain;
using Catalogs.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Catalogs.Tests
{
    public class UnitTest1
    {
        private readonly ProductRepository repo;
        private readonly UnitOfWork uow;

        public UnitTest1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Db>();
            optionsBuilder.UseSqlServer(
                "Server=.;Initial Catalog=Catalog;Integrated Security=true");
            var db = new Db(optionsBuilder.Options);
            repo = new ProductRepository(db);
            uow = new UnitOfWork(db);
        }

        [Fact]
        public void Test1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Db>();
            optionsBuilder.UseSqlServer(
                "Server=.;Initial Catalog=Catalog;Integrated Security=true");
            var db = new Db(optionsBuilder.Options);
            var repo = new ProductRepository(db);
            var uow = new UnitOfWork(db);

            var product = new Product(
                Guid.NewGuid(),
                "p1",
                2,
                1,
                "im.jpg");
            repo.Add(product);
            uow.Commit().Wait();
        }

        [Fact]
        public void Test2()
        {
            var productId = Guid.Parse("3BA2BAC3-8D93-4F15-8568-428B65E5E8C0");
            var product = repo.Get(productId).Result;
            Assert.NotNull(product);
            Assert.Equal("p1", product.Name);
        }
    }
}