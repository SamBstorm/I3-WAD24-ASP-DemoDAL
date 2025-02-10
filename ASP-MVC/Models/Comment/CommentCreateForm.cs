using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Comment
{
    public class CommentCreateForm
    {
        [DisplayName("Titre : ")]
        [Required(ErrorMessage = "Le champ 'Titre' est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champ 'Titre' doit contenir un minimum de 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le champ 'Titre' doit contenir un maximum de 64 caractères.")]
        public string Title { get; set; }
        [DisplayName("Votre commentaire : ")]
        [Required(ErrorMessage = "Le champ 'Commentaire' est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champ 'Commentaire' doit contenir un minimum de 2 caractères.")]
        [MaxLength(512, ErrorMessage = "Le champ 'Commentaire' doit contenir un maximum de 512 caractères.")]
        public string Content { get; set; }
        [DisplayName("Une note de 0 à 5 ?")]
        [Range(0,5,ErrorMessage = "Le champ 'Note' doit être compris entre 0 et 5.")]
        public int? Note { get; set; }
        [HiddenInput]
        public Guid Concern { get; set; }
        [HiddenInput]
        public Guid CreatedBy { get; set; }
    }
}
