using System;

namespace WebApplication1.Models.ViewModels
{
    public class ScoringModel
    {
        public int Id { get; set; }
        public string EmployeNom { get; set; }
        public string Critere { get; set; }
        public int Note { get; set; } // Exemple : 0 à 100
        public string Commentaire { get; set; }
        public DateTime DateEvaluation { get; set; }
    }
}
