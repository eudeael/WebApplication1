using System;

namespace WebApplication1.Models.ViewModels
{
    public class HistoriqueEmployeViewModel
    {
        public int Id { get; set; }
        public string EmployeNom { get; set; }
        public string PosteOccupe { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string Commentaire { get; set; }
    }
} 
