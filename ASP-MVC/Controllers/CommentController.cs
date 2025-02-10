using ASP_MVC.Models.Comment;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class CommentController : Controller
    {
        [HttpPost]
        public IActionResult Create(Guid id, CommentCreateForm form)
        {
            try
            {

            }
            catch (Exception)
            {

                return RedirectToAction("Details","Cocktails",new {id});
            }
        }
    }
}
