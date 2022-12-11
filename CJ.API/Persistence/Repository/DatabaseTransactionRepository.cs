using System.Data.Entity;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Persistence.Repository
{
    public class DatabaseTransactionRepository : IDatabaseTransactionRepository
    {
        private readonly DbContextTransaction _transaction;

        public DatabaseTransactionRepository(DbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}