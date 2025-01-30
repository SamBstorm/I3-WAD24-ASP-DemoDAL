using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.User
{
    public class UserEditForm
    {
        [DisplayName("Prénom : ")]
        [Required(ErrorMessage = "Le champ 'Prénom' est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champ 'Prénom' doit contenir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le champ 'Prénom' doit contenir au maximum 64 caractères.")]
        public string First_Name { get; set; }

        [DisplayName("Nom de famille : ")]
        [Required(ErrorMessage = "Le champ 'Nom de famille' est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champ 'Nom de famille' doit contenir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le champ 'Nom de famille' doit contenir au maximum 64 caractères.")]
        public string Last_Name { get; set; }

        [DisplayName("E-mail : ")]
        [Required(ErrorMessage = "Le champ 'Nom de famille' est obligatoire.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
