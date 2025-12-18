using System;

namespace WebApplication1.Models.ViewModels
{
    public class EmployeListItemModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public DateTime DateEntree { get; set; }
        public string Anciennete { get; set; }
        public string Adresse { get; set; }
        public string Poste { get; set; }
        public string Niveau { get; set; }
    }
}
