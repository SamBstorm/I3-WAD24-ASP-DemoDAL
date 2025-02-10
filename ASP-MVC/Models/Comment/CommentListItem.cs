using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Comment
{
    public class CommentListItem
    {
        [ScaffoldColumn(false)]
        public Guid Comment_Id { get; set; }
        [DisplayName("Titre :")]
        public string Title { get; set; }
        public string Content { get; set; }
        [DisplayName("Cocktail : ")]
        public string Cocktail { get; set; }
        [ScaffoldColumn(false)]
        public Guid Concern { get; set;}
        [DisplayName("écrit par :")]
        public string? Creator { get; set; }
        [ScaffoldColumn(false)]
        public Guid? CreatedBy { get; set; }
        [DisplayName("Rédigé le :")]
        [DataType("datetime-local")]
        public DateTime CreatedAt { get; set; }
        public int? Note { get; set; }
    }
}
