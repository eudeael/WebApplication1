using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<ProfilEmploye> Employes { get; set; }
        public DbSet<OffresEmploi> Offres { get; set; }
        public DbSet<HistoriqueEmploye> Historiques { get; set; }
        public DbSet<Scoring> Scores { get; set; }
    }
}
