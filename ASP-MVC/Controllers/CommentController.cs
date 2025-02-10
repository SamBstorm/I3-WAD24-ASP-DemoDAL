using ASP_MVC.Mappers;
using ASP_MVC.Models.Comment;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class CommentController : Controller
    {
        private ICommentRepository<Comment> _commentRepository;
        public CommentController(ICommentRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpPost]
        public IActionResult Create(Guid id, CommentCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                _commentRepository.Insert(form.ToBLL());
                return RedirectToAction("Details", "Cocktail", new { id });
            }
            catch (Exception)
            {

                return RedirectToAction("Details","Cocktail",new {id});
            }
        }
    }
}
