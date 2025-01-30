using ASP_MVC.Mappers;
using ASP_MVC.Models.User;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository<BLL.Entities.User> _userService;

        public UserController(IUserRepository<BLL.Entities.User> userService)
        {
            _userService = userService;
        }

        // GET: UserController
        public ActionResult Index()
        {
            try
            {
                IEnumerable<UserListItem> model = _userService.Get().Select(bll => bll.ToListItem());
                return View(model);
            }
            catch (Exception ex) {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {
            try
            {
                UserDetails model = _userService.Get(id).ToDetails();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateForm form)
        {
            try
            {
                if (!form.Consent) ModelState.AddModelError(nameof(form.Consent),"Vous devez lire et accepter les conditions générales d'utilisation.");
                if (!ModelState.IsValid) throw new ArgumentException();
                Guid id = _userService.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
