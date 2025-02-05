using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using D = DAL.Entities;

namespace BLL.Mappers
{
    internal static class Mapper
    {
        #region Users
        public static User ToBLL(this D.User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new User(
                user.User_Id,
                user.First_Name,
                user.Last_Name,
                user.Email,
                user.Password,
                user.CreatedAt,
                user.DisabledAt,
                user.Role);
        }

        public static D.User ToDAL(this User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new D.User()
            {
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                DisabledAt = (user.IsDisabled) ? new DateTime() : null,
                Role = user.Role.ToString()
            };
        }
        #endregion

        #region Cocktails
        public static Cocktail ToBLL(this D.Cocktail cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new Cocktail(
                cocktail.Cocktail_Id,
                cocktail.Name,
                cocktail.Description,
                cocktail.Instructions,
                DateOnly.FromDateTime(cocktail.CreatedAt),
                cocktail.CreatedBy
                );
        }

        public static D.Cocktail ToDAL(this Cocktail cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new D.Cocktail()
            {
                Cocktail_Id = cocktail.Cocktail_Id,
                Name = cocktail.Name,
                Description = cocktail.Description,
                Instructions = cocktail.Instructions,
                CreatedAt = cocktail.CreatedAt.ToDateTime(new TimeOnly()),
                CreatedBy = cocktail.CreatedBy
            };
        }
        #endregion
    }
}
