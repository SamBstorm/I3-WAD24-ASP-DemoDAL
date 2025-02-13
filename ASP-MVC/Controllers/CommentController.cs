using ASP_MVC.Handlers;
using ASP_MVC.Handlers.ActionFilters;
using ASP_MVC.Mappers;
using ASP_MVC.Models.Comment;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASP_MVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository<Comment> _commentRepository;
        private readonly SessionManager _sessionManager;
        public CommentController(
            ICommentRepository<Comment> commentRepository,
            SessionManager sessionManager
            )
        {
            _commentRepository = commentRepository;
            _sessionManager = sessionManager;
        }

        [HttpGet]
        [ConnectionNeeded]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<CommentListItem> model = _commentRepository.GetByUserId(_sessionManager.ConnectedUser!.User_Id).Select(bll => bll.ToListItem());
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        [ConnectionNeeded]
        public IActionResult Edit(Guid id) {
            try
            {
                CommentEditForm model = _commentRepository.Get(id).ToEditForm();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ConnectionNeeded]
        public IActionResult Edit(Guid id, CommentEditForm form)
        {
            try
            {
                if(!ModelState.IsValid) throw new ArgumentException(nameof(form));
                _commentRepository.Update(id, form.ToBLL());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        [ConnectionNeeded]
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

        [HttpGet]
        [ConnectionNeeded]
        public IActionResult Delete(Guid id) {
            try
            {
                CommentDelete model = _commentRepository.Get(id).ToDelete();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ConnectionNeeded]
        public IActionResult Delete(Guid id, CommentDelete form)
        {
            try
            {
                _commentRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Error","Home");
            }
        }
    }
}
