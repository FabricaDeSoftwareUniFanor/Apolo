using ApoloWebApi.Data.VO.Evaluations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApoloWebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<RiscoCoronariano> RiscosCoronarianos { get; set; }
        public DbSet<Anamnese> Anamneses { get; set; }
        public DbSet<Antropometria> Antropometrias { get; set; }
        public DbSet<AvaliacaoPostural> AvaliacoesFisicas { get; set; }
        public DbSet<Flexiteste> Flexitestes { get; set; }
        public DbSet<Retracao> Retracoes { get; set; }
        public DbSet<JSMPF> JSMPFs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
