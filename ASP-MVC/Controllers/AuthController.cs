using ASP_MVC.Handlers;
using ASP_MVC.Handlers.ActionFilters;
using ASP_MVC.Models.Auth;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository<BLL.Entities.User> _userService;
        private SessionManager _sessionManager;

        public AuthController(
            IUserRepository<User> userService,
            SessionManager sessionManager
            )
        {
            _userService = userService;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        [AnonymousNeeded]
        public IActionResult Login()
        {
            /* Méthode compliquée de vérifier si l'utilisateur à le droit ou non d'accéder à la page...
            if(_sessionManager.ConnectedUser is not null)
            {
                return RedirectToAction("Index", "Home");
            }*/
            return View();
        }

        [HttpPost]
        [AnonymousNeeded]
        public IActionResult Login(AuthLoginForm form) {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                Guid id = _userService.CheckPassword(form.Email, form.Password);
                //C'est ici que nous définirons la variable de session
                ConnectedUser user = new ConnectedUser() { 
                    User_Id = id,
                    Email = form.Email,
                    ConnectedAt = DateTime.Now
                };
                _sessionManager.Login(user);
                return RedirectToAction("Details", "User", new { id = id });
            }
            catch (Exception)
            {
                return View();
            }
        }

        [ConnectionNeeded]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        [ConnectionNeeded]
        public IActionResult Logout(IFormCollection form)
        {
            try
            {
                _sessionManager.Logout();
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
