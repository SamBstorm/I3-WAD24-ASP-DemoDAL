﻿using BLL.Entities;
using BLL.Mappers;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CocktailService : ICocktailRepository<Cocktail>
    {
        private ICocktailRepository<DAL.Entities.Cocktail> _cocktailService;
        private ICommentRepository<DAL.Entities.Comment> _commentService;
        private IUserRepository<DAL.Entities.User> _userService;

        public CocktailService(
            ICocktailRepository<DAL.Entities.Cocktail> cocktailService,
            IUserRepository<DAL.Entities.User> userService,
            ICommentRepository<DAL.Entities.Comment> commentService)
        {
            _cocktailService = cocktailService;
            _userService = userService;
            _commentService = commentService;
        }

        public void Delete(Guid cocktail_id)
        {
            _cocktailService.Delete(cocktail_id);
        }

        public IEnumerable<Cocktail> Get()
        {
            IEnumerable<Cocktail> cocktails = _cocktailService.Get().Select(dal => dal.ToBLL());
            foreach (Cocktail cocktail in cocktails)
            {
                if (cocktail.CreatedBy is not null)
                {
                    cocktail.SetCreator(_userService.Get((Guid)cocktail.CreatedBy).ToBLL());
                }
            }
            return cocktails;
        }

        public Cocktail Get(Guid cocktail_id)
        {
            Cocktail cocktail = _cocktailService.Get(cocktail_id).ToBLL();
            if(cocktail.CreatedBy is not null)
            {
                cocktail.SetCreator(_userService.Get((Guid)cocktail.CreatedBy).ToBLL());
            }
            cocktail.AddComments(_commentService.GetByCocktailId(cocktail_id).Select(dal=> dal.ToBLL()));
            foreach (Comment comment in cocktail.Comments)
            {
                comment.SetCocktail(cocktail);
                if(comment.CreatedBy is not null)
                {
                    comment.SetCreator(_userService.Get((Guid)comment.CreatedBy).ToBLL());
                }
            }
            return cocktail;
        }

        public IEnumerable<Cocktail> GetFromUser(Guid user_id)
        {
            return _cocktailService.GetFromUser(user_id).Select(dal => dal.ToBLL());
        }

        public Guid Insert(Cocktail cocktail)
        {
            return _cocktailService.Insert(cocktail.ToDAL());
        }

        public void Update(Guid cocktail_id, Cocktail cocktail)
        {
            _cocktailService.Update(cocktail_id, cocktail.ToDAL());
        }
    }
}
