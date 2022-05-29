using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PropertyPortal.Data;
using PropertyPortal.Repositories.Interfaces;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PropertyPortal.Controllers
{
    [Authorize]
    public class ControllerBase : Controller
    {
        protected readonly IUnitOfWork _uow;
        protected readonly UserManager<ApplicationUser> _userManager;
        
        private ApplicationUser _currentUser;



        public ControllerBase(IUnitOfWork uow, UserManager<ApplicationUser> userManager)
        {
            _uow = uow;
            _userManager = userManager;
        }


        protected async Task<ApplicationUser> GetUser()
        {
            if(_currentUser == null)
                _currentUser = await _userManager.GetUserAsync(User);
            return _currentUser;

        }
    }
}
