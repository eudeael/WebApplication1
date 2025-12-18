using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<ProfilExterne> ProfilsExternes { get; set; }
        // autres DbSet (Employe, Offre, etc.)
    }
}
