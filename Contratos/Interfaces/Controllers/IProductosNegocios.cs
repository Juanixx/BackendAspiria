using Contratos.Modelos;
using System.Threading.Tasks;
using System.Web.Http;

namespace Contratos.Interfaces.Controllers
{
    public interface IProductosNegocios
    {
        Task<IHttpActionResult> CrearProducto(ProductoDto productoDto);
        Task<IHttpActionResult> ObtenerProductos();
        Task<IHttpActionResult> Actualizar(ProductoDto productoDto);
        Task<IHttpActionResult> EliminarProducto(int productoId);
    }
}
