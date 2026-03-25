using System;
using System.Collections.Generic;

namespace WebApplication1.Models.ViewModels
{
    public class EmploisParEmployeVM
    {
        public int IdProfil { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public int Age { get; set; }
        public DateTime DateEmbauche { get; set; }
        public string Anciennete { get; set; }
        public string Adresse { get; set; }
        public string PosteActuel { get; set; }
        public string NiveauActuel { get; set; }
        public List<EmploiRowVM> OffresCompatibles { get; set; } = new List<EmploiRowVM>();
    }
}
