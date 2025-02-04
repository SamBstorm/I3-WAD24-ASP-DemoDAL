using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailDetails
    {
        [ScaffoldColumn(false)]
        public Guid Cocktail_Id { get; set; }
        [DisplayName("Cocktail : ")]
        public string Name { get; set; }
        [DisplayName("Description : ")]
        public string? Description { get; set; }
        [DisplayName("Recette : ")]
        [DataType(DataType.MultilineText)]
        public string Instructions { get; set; }
        [DisplayName("Créé par : ")]
        public string? Creator { get; set; }
        [ScaffoldColumn(false)]
        public Guid? CreatedBy { get; set; }
        [DisplayName("Créé le : ")]
        [DataType(DataType.Date)]
        public DateOnly CreatedAt { get; set; }
    }
}
