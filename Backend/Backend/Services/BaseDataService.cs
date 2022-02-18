using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public abstract class BaseDataService<T>
        where T : DbContext
    {
        private readonly T _dbContext;
        private readonly ILogger<T> _logger;

        public BaseDataService(
            T dbContext,
            ILogger<T> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        protected async Task<TData> ExecuteSafe<TData>(Func<Task<TData>> action)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var result = await action();
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, "Transaction is rollbacked");
                    return default(TData) !;
                }
            }
        }
    }
}
