using ASP_MVC.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class DemoController : Controller
    {
        private SessionManager _sessionManager;

        public DemoController(SessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            //int count = HttpContext.Session.GetInt32("CountVisitedPage") ?? 0;
            //count++;
            //HttpContext.Session.SetInt32("CountVisitedPage", count);
            int count = _sessionManager.CountVisitedPage;
            count++;
            _sessionManager.CountVisitedPage = count;
            return View();
        }

        public IActionResult PlusOne()
        {
            int count = HttpContext.Session.GetInt32("CountVisitedPage") ?? 0;
            count++;
            HttpContext.Session.SetInt32("CountVisitedPage", count);
            return View("Index");
        }
    }
}
