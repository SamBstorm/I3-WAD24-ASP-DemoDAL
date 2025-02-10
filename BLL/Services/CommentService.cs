using BLL.Entities;
using BLL.Mappers;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : ICommentRepository<Comment>
    {
        private readonly ICommentRepository<DAL.Entities.Comment> _commentService;
        private readonly IUserRepository<DAL.Entities.User> _userService;
        private readonly ICocktailRepository<DAL.Entities.Cocktail> _cocktailService;

        public CommentService(
            ICommentRepository<DAL.Entities.Comment> commentService, 
            IUserRepository<DAL.Entities.User> userService, 
            ICocktailRepository<DAL.Entities.Cocktail> cocktailService
            )
        {
            _commentService = commentService;
            _userService = userService;
            _cocktailService = cocktailService;
        }

        public void Delete(Guid id)
        {
            _commentService.Delete(id);
        }

        public Comment Get(Guid id)
        {
            Comment comment = _commentService.Get(id).ToBLL();
            comment.SetCocktail(_cocktailService.Get(comment.Concern).ToBLL());
            if (comment.CreatedBy is not null)
            {
                comment.SetCreator(_userService.Get((Guid)comment.CreatedBy).ToBLL());
            }
            return comment;
        }

        public IEnumerable<Comment> GetByCocktailId(Guid cocktail_id)
        {
            IEnumerable<Comment> comments = _commentService.GetByCocktailId(cocktail_id).Select(dal => dal.ToBLL());
            Cocktail cocktail = _cocktailService.Get(cocktail_id).ToBLL();
            foreach (Comment comment in comments)
            {
                comment.SetCocktail(cocktail);
                if (comment.CreatedBy is not null)
                {
                    comment.SetCreator(_userService.Get((Guid)comment.CreatedBy).ToBLL());
                }
            }
            return comments;
        }

        public IEnumerable<Comment> GetByUserId(Guid user_id)
        {
            IEnumerable<Comment> comments = _commentService.GetByUserId(user_id).Select(dal => dal.ToBLL());
            User user = _userService.Get(user_id).ToBLL();
            foreach (Comment comment in comments)
            {
                comment.SetCreator(user);
                comment.SetCocktail(_cocktailService.Get(comment.Concern).ToBLL());
            }
            return comments;
        }

        public Guid Insert(Comment entity)
        {
            return _commentService.Insert(entity.ToDAL());
        }

        public void Update(Guid id, Comment entity)
        {
            _commentService.Update(id, entity.ToDAL());
        }
    }
}
