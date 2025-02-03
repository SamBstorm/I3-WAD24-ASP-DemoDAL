using ASP_MVC.Mappers;
using ASP_MVC.Models.Cocktail;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class CocktailController : Controller
    {
        private ICocktailRepository<Cocktail> _cocktailRepository;

        public CocktailController(ICocktailRepository<Cocktail> cocktailRepository)
        {
            _cocktailRepository = cocktailRepository;
        }

        // GET: CocktailController
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CocktailListItem> model = _cocktailRepository.Get().Select(bll => bll.ToListItem());
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: CocktailController/Details/5
        public ActionResult Details(Guid id)
        {
            try
            {
                CocktailDetails model = _cocktailRepository.Get(id).ToDetails();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: CocktailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CocktailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CocktailCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                Guid id = _cocktailRepository.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View();
            }
        }

        // GET: CocktailController/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                CocktailEditForm model = _cocktailRepository.Get(id).ToEditForm();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: CocktailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, CocktailEditForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                _cocktailRepository.Update(id, form.ToBLL());
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View();
            }
        }

        // GET: CocktailController/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                CocktailDelete model = _cocktailRepository.Get(id).ToDelete();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: CocktailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, CocktailDelete form)
        {
            try
            {
                _cocktailRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
