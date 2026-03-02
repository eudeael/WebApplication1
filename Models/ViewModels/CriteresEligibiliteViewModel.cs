using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public class CriteresEligibiliteViewModel
    {
        [Key] // identifiant pour le mapping
        public int IdCritere { get; set; }

        [Required(ErrorMessage = "Le nom du critère est obligatoire")]
        [Display(Name = "Nom du critère")]
        public string NomCritere { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Poids (importance)")]
        public int? Poids { get; set; }

        // Champ calculé ou simplifié pour l'affichage
        [Display(Name = "Nombre d'offres liées")]
        public int NbOffresLiees { get; set; }
    }
}
