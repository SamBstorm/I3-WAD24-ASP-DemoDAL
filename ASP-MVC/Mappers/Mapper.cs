using ASP_MVC.Models.Cocktail;
using ASP_MVC.Models.Comment;
using ASP_MVC.Models.User;
using BLL.Entities;

namespace ASP_MVC.Mappers
{
    internal static class Mapper
    {
        #region Users
        public static UserListItem ToListItem(this User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserListItem()
            {
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name
            };
        }

        public static UserDetails ToDetails(this User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserDetails()
            {
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                CreatedAt = DateOnly.FromDateTime(user.CreatedAt),
                Cocktails = user.Cocktails.Select(bll => bll.ToListItem())
            };
        }

        public static User ToBLL(this UserCreateForm user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new User(
                Guid.Empty,
                user.First_Name,
                user.Last_Name,
                user.Email,
                user.Password,
                DateTime.Now,
                null,
                "User"
                );
            /*return new User(
                user.First_Name,
                user.Last_Name,
                user.Email,
                user.Password);*/
        }

        public static UserEditForm ToEditForm(this User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserEditForm()
            {
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email
            };
        }

        public static User ToBLL(this UserEditForm user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            /*return new User(
                Guid.Empty,
                user.First_Name,
                user.Last_Name,
                user.Email,
                "********",
                DateTime.Now,
                null,
                "User"
                );*/
            return new User(
                user.First_Name,
                user.Last_Name,
                user.Email);
        }

        public static UserDelete ToDelete(this User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserDelete()
            {
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email
            };
        }
        #endregion
        #region Cocktails
        public static CocktailListItem ToListItem(this Cocktail cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailListItem()
            {
                Cocktail_Id = cocktail.Cocktail_Id,
                Name = cocktail.Name,
                Description = cocktail.Description
            };
        }

        public static CocktailDetails ToDetails(this Cocktail cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailDetails()
            {
                Cocktail_Id = cocktail.Cocktail_Id,
                Name = cocktail.Name,
                Description = cocktail.Description,
                Instructions = cocktail.Instructions,
                CreatedAt = cocktail.CreatedAt,
                Creator = (cocktail.Creator is null) ? null : $"{cocktail.Creator.First_Name} {cocktail.Creator.Last_Name}",
                CreatedBy = cocktail.CreatedBy,
                Comments = cocktail.Comments.Select(c => c.ToListItem())
            };
        }

        public static Cocktail ToBLL(this CocktailCreateForm cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new Cocktail(
                Guid.Empty,
                cocktail.Name,
                cocktail.Description,
                cocktail.Instructions,
                DateTime.Now,
                cocktail.CreatedBy
                );
        }

        public static CocktailEditForm ToEditForm(this Cocktail cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailEditForm()
            {
                Name = cocktail.Name,
                Description = cocktail.Description,
                Instructions= cocktail.Instructions
            };
        }

        public static Cocktail ToBLL(this CocktailEditForm cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new Cocktail(
                Guid.Empty,
                cocktail.Name,
                cocktail.Description,
                cocktail.Instructions,
                DateTime.Now,
                Guid.Empty
                );
        }

        public static CocktailDelete ToDelete(this Cocktail cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailDelete()
            {
                Name= cocktail.Name,
                Description= cocktail.Description,
                CreatedBy = cocktail.CreatedBy
            };
        }
        #endregion
        #region Comments
        public static CommentListItem ToListItem(this Comment comment)
        {
            if(comment is null) throw new ArgumentNullException( nameof(comment));
            return new CommentListItem()
            {
                Comment_Id = comment.Comment_Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                CreatedBy = comment.CreatedBy,
                Concern = comment.Concern,
                Cocktail = comment.Cocktail.Name,
                Creator = comment.CreatedBy is null ? null : $"{comment?.Creator?.First_Name} {comment?.Creator?.Last_Name}",
            };
        }

        public static CommentEditForm ToEditForm(this Comment comment)
        {
            if (comment is null) throw new ArgumentNullException(nameof(comment));
            return new CommentEditForm()
            {
                Title = comment.Title,
                Content = comment.Content,
                CreatedBy = (Guid)comment.CreatedBy!,
                Concern = comment.Concern
            };
        }
        public static CommentDelete ToDelete(this Comment comment)
        {
            if (comment is null) throw new ArgumentNullException(nameof(comment));
            return new CommentDelete()
            {
                Title = comment.Title,
                Content = comment.Content,
                Cocktail = comment.Cocktail!.Name,
                CreatedAt = comment.CreatedAt,
                Note = comment.Note
            };
        }

        public static Comment ToBLL(this CommentEditForm comment)
        {
            if (comment is null) throw new ArgumentNullException(nameof(comment));
            return new Comment(
                comment.Title,
                comment.Content,
                comment.Concern,
                comment.CreatedBy,
                comment.Note
                );
        }
        public static Comment ToBLL(this CommentCreateForm comment)
        {
            if (comment is null) throw new ArgumentNullException(nameof(comment));
            return new Comment(
                comment.Title,
                comment.Content,
                comment.Concern,
                comment.CreatedBy,
                comment.Note
                );
        }
        #endregion
    }
}
