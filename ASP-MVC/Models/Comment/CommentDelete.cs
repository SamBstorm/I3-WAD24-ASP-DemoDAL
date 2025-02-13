using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Comment
{
    public class CommentDelete
    {
        [DisplayName("Titre :")]
        public string Title { get; set; }
        [DisplayName("Commentaire : ")]
        public string Content { get; set; }
        [DisplayName("Cocktail : ")]
        public string Cocktail { get; set; }
        [DisplayName("Rédigé le :")]
        [DataType("datetime-local")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Avec la note de : ")]
        public int? Note { get; set; }
    }
}
