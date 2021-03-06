﻿using Contratos.Modelos;
using Repositorios.Connections;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.Configuration;

namespace Repositorios.Database
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
