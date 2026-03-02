using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }
        // DbSets = tables
        public DbSet<OffresEmploi> OffresEmploi { get; set; }
        public DbSet<ProfilEmploye> ProfilsEmployes { get; set; }
        public DbSet<ProfilExterne> ProfilsExternes { get; set; }
        public DbSet<Diplome> Diplomes { get; set; }
        public DbSet<Postes> Postes { get; set; }
        public DbSet<Scoring> Scorings { get; set; }
        public DbSet<ProfilScoring> ProfilsScoring { get; set; }
        public DbSet<HistoriqueEmploye> HistoriquesEmployes { get; set; }
        public DbSet<CriteresEligibilite> CriteresEligibilite { get; set; }
    }
}