using ASP_MVC.Handlers.ActionFilters;
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

        [AnonymousNeeded]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousNeeded]
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
        public ActionResult Edit(Guid id)
        {
            try
            {
                UserEditForm model = _userService.Get(id).ToEditForm();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, UserEditForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                _userService.Update(id, form.ToBLL());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit), new { id = id });
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                UserDelete model = _userService.Get(id).ToDelete();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error","Home");
            }
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, UserDelete form)
        {
            try
            {
                _userService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Delete), new { id = id });
            }
        }

        //[AdminNeeded("Admin","Autor","User")]
        [AdminNeeded]
        public IActionResult ChangeRole(Guid id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AdminNeeded("Admin", "Autor", "User")]
        [AdminNeeded]
        public IActionResult ChangeRole(Guid id, IFormCollection collection)
        {
            try
            {
                //Vérifier le formulaire
                //Demander un changement en DB
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
