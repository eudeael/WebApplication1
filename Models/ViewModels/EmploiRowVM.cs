namespace WebApplication1.Models.ViewModels
{
    public class EmploiRowVM
    {
        public int IdOffre { get; set; }
        public string IntitulePoste { get; set; }
        public string Localisation { get; set; }
        public string NiveauPoste { get; set; }
        public double DistanceKm { get; set; }
        public double Salaire { get; set; }
        public string TypeContrat { get; set; }
        public bool TeletravailPossible { get; set; }
    }
}
