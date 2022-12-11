using System;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Models.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDatabaseTransactionRepository BeginTransaction();
        //ISmsApiCredentialRepository SmsApiCredentials { get; }
        int Save();
    }
}
