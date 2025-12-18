using System;

namespace WebApplication1.Models.ViewModels
{
    public class ProfilExterneViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime DateCandidature { get; set; }
        public string Diplome { get; set; }
        public string OffreEmploi { get; set; }
    }
}
