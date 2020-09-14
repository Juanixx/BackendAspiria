using Contratos.Modelos;
using Repository.Connections;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repository.Database
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext()
            : base(DatabaseConnection.getDbConnection())
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
