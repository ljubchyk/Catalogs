namespace Catalogs.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Db db;

        public UnitOfWork(Db db)
        {
            this.db = db;
        }

        public async Task Commit()
        {
            await db.SaveChangesAsync();

            //use outbox
            throw new NotImplementedException();
        }
    }
}