using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public class OffreViewModel
    {
        public int IdOffre { get; set; }

        [Required(ErrorMessage = "L'intitulé du poste est obligatoire")]
        [Display(Name = "Intitulé du poste")]
        public string IntitulePoste { get; set; }

        [Display(Name = "Localisation")]
        public string Localisation { get; set; }

        [Display(Name = "Type de contrat")]
        public string TypeContrat { get; set; }

        [Display(Name = "Télétravail possible")]
        public bool TeletravailPossible { get; set; }

        [Display(Name = "Salaire proposé")]
        public double SalairePropose { get; set; }

        [Display(Name = "Date de publication")]
        public DateTime DatePublication { get; set; }

        [Display(Name = "Date limite de candidature")]
        public DateTime DateLimiteCandidature { get; set; }

        [Display(Name = "Nombre de postes ouverts")]
        public int NbPostesOuverts { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
    // Petit modèle pour représenter un diplôme
    public class DiplomeItemModel
    {
        public int IdDiplome { get; set; }
        public string Intitule { get; set; }
        public string Niveau { get; set; }
        public DateTime DateObtention { get; set; }
    }
}
