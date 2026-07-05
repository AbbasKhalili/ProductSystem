using Shared.Core;

namespace Shared.EF
{
    internal class UnitOfWork(EFContext context) : IUnitOfWork
    {
        private readonly EFContext _context = context;

        public Task SaveChangesAsync() => _context.SaveChangesAsync();

        public async Task Begin()
        {
            //await _context.Instance.Database.BeginTransactionAsync();

            //var strategy = _context.Instance.Database.CreateExecutionStrategy();

            //await strategy.ExecuteAsync(async () =>
            //{
            //    using var transaction = await _context.Instance.Database.BeginTransactionAsync();

            //    // ALL your DB operations here
            //    await _context.Instance.SaveChangesAsync();

            //    await transaction.CommitAsync();
            //});
        }

        public async Task Commit()
        {
            //await _context.Instance.SaveChangesAsync();
            //await _context.Instance.Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
           // await _context.Instance.Database.RollbackTransactionAsync();
        }
        private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposed)
        //    {
        //        if (disposing)
        //        {
        //            _context.Instance.Dispose();
        //        }
        //    }
        //    disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }

}
