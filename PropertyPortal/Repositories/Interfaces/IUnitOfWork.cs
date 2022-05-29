using System;

namespace PropertyPortal.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPropertyRepository Properties { get; }
        ITransactionRepository Transactions { get; }
        int Complete();
    }
}
