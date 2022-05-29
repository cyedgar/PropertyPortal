using PropertyPortal.Data;
using PropertyPortal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using PropertyPortal.Extensions;

namespace PropertyPortal.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private UserManager<ApplicationUser> _userManager;
        public TransactionRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public IEnumerable<Transaction> GetTransactionsByUserId(bool IsAdmin, string UserId)
        {
            if (IsAdmin)
            {
                return (from t in _table
                        join u in _userManager.Users
                        on t.UserId equals u.Id
                        where t.UserId == UserId || u.IsAdministrator == false
                        select t).IncludeMultiple(i => i.Property, i => i.User);
            }
            else
            {
                return GetTransactionsByUserId(UserId);
            }
        }
        public IEnumerable<Transaction> GetTransactionsByUserId(string UserId)
        {

            return _table.IncludeMultiple(i => i.Property, i => i.User).Where(o => o.UserId == UserId).ToList();
          
        }


        public Transaction GetTransactionById(int id)
        {
            return _table.IncludeMultiple(i => i.Property, i => i.User).FirstOrDefault(o => o.TransactionId == id);
        }
    }
}
