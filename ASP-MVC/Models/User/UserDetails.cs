using ASP_MVC.Models.Cocktail;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.User
{
    public class UserDetails
    {
        [ScaffoldColumn(false)]
        public Guid User_Id { get; set; }
        [DisplayName("Prénom : ")]
        public string First_Name { get; set; }
        [DisplayName("Nom de famille : ")]
        public string Last_Name { get; set; }
        [DisplayName("E-mail : ")]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Date d'inscription : ")]
        [DataType(DataType.Date)]
        public DateOnly CreatedAt { get; set; }
        [DisplayName("Vos cocktails : ")]
        public IEnumerable<CocktailListItem> Cocktails { get; set; }
    }
}
