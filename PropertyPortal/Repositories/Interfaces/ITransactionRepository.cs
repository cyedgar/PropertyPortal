using PropertyPortal.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PropertyPortal.Repositories.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        IEnumerable<Transaction> GetTransactionsByUserId(bool IsAdmin, string UserId);

        IEnumerable<Transaction> GetTransactionsByUserId(string UserId);

        Transaction GetTransactionById(int id);

    }
}
