using Contratos.Interfaces.Repositorios;
using Contratos.Modelos;
using Repository.Database;

namespace Negocios.NegociosRepositorios
{
    public class ProductosRepositorio : GenericRepository<Producto>, IProductosRepositorio
    {
        public ProductosRepositorio(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
