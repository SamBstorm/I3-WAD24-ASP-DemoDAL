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
            return View();
        }

        // GET: CocktailController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CocktailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CocktailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CocktailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CocktailController/Edit/5
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

        // GET: CocktailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CocktailController/Delete/5
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
