using Contratos.Interfaces.Repositorios;
using Contratos.Modelos;
using Repositorios.Database;

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
