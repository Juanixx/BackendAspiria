using Contratos.Modelos;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repositorios.Database
{
    public class ApplicationDbContext : DbContext
    {
        private static string _dbConnection => Properties.Settings.Default.AspiriaConnection;
        public ApplicationDbContext()
            : base(_dbConnection)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
