using System;

namespace CJ.API.Models.Core.Repository
{
    public interface IDatabaseTransactionRepository  : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
