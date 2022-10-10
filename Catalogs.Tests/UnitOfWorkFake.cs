using Catalogs.Infrastructure;

namespace Catalogs.Tests
{
    public class UnitOfWorkFake : IUnitOfWork
    {
        private bool isCommited;

        public bool IsCommited => isCommited;

        public Task Commit()
        {
            isCommited = true;
            return Task.CompletedTask;
        }
    }
}