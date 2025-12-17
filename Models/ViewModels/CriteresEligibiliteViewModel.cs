using System;

namespace WebApplication1.Models.ViewModels
{
    public class CriteresEligibiliteViewModel
    {
        public int Id { get; set; }
        public string NomCritere { get; set; }
        public string Description { get; set; }

        public int Poids { get; set; }

    }
}