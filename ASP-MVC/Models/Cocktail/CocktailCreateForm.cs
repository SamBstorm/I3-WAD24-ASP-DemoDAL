﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailCreateForm
    {
        [DisplayName("Nom du cocktail : ")]
        [Required(ErrorMessage = "Le champ 'Nom du cocktail' est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champ 'Nom du cocktail' doit contenir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le champ 'Nom du cocktail' doit contenir au maximum 64 caractères.")]
        public string Name { get; set; }
        [DisplayName("Description : ")]
        [MinLength(2, ErrorMessage = "Le champ 'Description' doit contenir au minimum 2 caractères.")]
        [MaxLength(512, ErrorMessage = "Le champ 'Description' doit contenir au maximum 512 caractères.")]
        public string? Description { get; set; }
        [DisplayName("Recette : ")]
        [Required(ErrorMessage = "Le champ 'Recette' est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champ 'Recette' doit contenir au minimum 2 caractères.")]
        public string Instructions { get; set; }
        [DisplayName("Créé par : ")]
        [Required(ErrorMessage = "Veuillez sélectionner un créateur.")]
        public Guid CreatedBy { get; set; }
    }
}
