namespace Repositorios.Migrations
{
    using Contratos.Modelos;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Database.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Productos.AddOrUpdate(e => e.Nombre, new Producto()
            {
                Nombre = "Muñeca",
                Compania = "Barbi´s company",
                Descripcion = "Muñeca para niñas",
                Precio = 13.23M,
                RestriccionEdad = 6
            });

            context.Productos.AddOrUpdate(e => e.Nombre, new Producto()
            {
                Nombre = "Hot wheel",
                Compania = "Matel",
                Descripcion = "Auto profesional de carreras",
                Precio = 59,
                RestriccionEdad = 8
            });

            context.Productos.AddOrUpdate(e => e.Nombre, new Producto()
            {
                Nombre = "Bicicleta",
                Compania = "Bicicleta S.A.",
                Descripcion = "Bicicleta para niños",
                Precio = 999.99M,
                RestriccionEdad = 18
            });

            context.Productos.AddOrUpdate(e => e.Nombre, new Producto()
            {
                Nombre = "Tren",
                Compania = "Rocker Feller",
                Descripcion = "Tren de madera",
                Precio = 99,
                RestriccionEdad = 10
            });

            context.Productos.AddOrUpdate(e => e.Nombre, new Producto()
            {
                Nombre = "Operación",
                Compania = "Doctor A.A. de S.L.",
                Descripcion = "Juego para aprender a operar personas",
                Precio = 999.99M,
                RestriccionEdad = 21
            });
        }
    }
}
