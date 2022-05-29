using PropertyPortal.Data;
using PropertyPortal.Repositories.Interfaces;
using System;

namespace PropertyPortal.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPropertyRepository Properties { get; }
        public ITransactionRepository Transactions { get; }

        public UnitOfWork(ApplicationDbContext dbContext,
            IPropertyRepository propertyRepository,
            ITransactionRepository transactionRepository)
        {
            this._context = dbContext;

            this.Properties = propertyRepository;
            this.Transactions = transactionRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
