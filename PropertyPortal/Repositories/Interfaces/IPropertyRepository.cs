using PropertyPortal.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyPortal.Repositories.Interfaces
{
    public interface IPropertyRepository : IGenericRepository<Property>
    {
        IEnumerable<Property> GetPropertiesByUserId(bool IsAdmin, string UserId);
        IEnumerable<Property> GetPropertiesByUserId(string UserId);

        Property GetPropertyById(int id);

    }
}
