using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailDelete
    {
        [DisplayName("Cocktail : ")]
        public string Name { get; set; }
        [DisplayName("Description : ")]
        public string? Description { get; set; }
        [DisplayName("Créé par : ")]
        public Guid? CreatedBy { get; set; }
    }
}
