using PropertyPortal.Data;
using PropertyPortal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using PropertyPortal.Extensions;

namespace PropertyPortal.Repositories
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        UserManager<ApplicationUser> _userManager;
        public PropertyRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public IEnumerable<Property> GetPropertiesByUserId(bool IsAdmin, string UserId)
        {
            if (IsAdmin)
            {
                return (from t in _table
                        join u in _userManager.Users
                        on t.UserId equals u.Id
                        where t.UserId == UserId || u.IsAdministrator == false
                        select t).IncludeMultiple(i => i.User);


            }
            else
            {
                return GetPropertiesByUserId(UserId);
            }
        }

        public IEnumerable<Property> GetPropertiesByUserId(string UserId)
        {
           
            return _table.Where(o => o.UserId == UserId).IncludeMultiple(i => i.User).ToList();
        }

        public Property GetPropertyById(int id)
        {
            return _table.IncludeMultiple(i => i.User).FirstOrDefault(o => o.PropertyId == id);
        }

    }
}
