using Contratos.Interfaces.Controllers;
using Contratos.Modelos;
using Negocios.Help;
using System.Threading.Tasks;
using System.Web.Http;

namespace EjercicioAspiriaBack.Controllers
{
    [RoutePrefix("api/v1/aspiria/products")]
    public class ProductosController : ApiController
    {
        private readonly IProductosNegocios _productosNegocios;
        public ProductosController(IProductosNegocios productosNegocios)
        {
            this._productosNegocios = productosNegocios;
        }

        [Route("")]
        public async Task<IHttpActionResult> GetProductos()
        {
            return await _productosNegocios.ObtenerProductos();
        }

        [Route("")]
        public async Task<IHttpActionResult> PostProduct(ProductoDto productoDto)
        {
            if (!ModelState.IsValid)
            {
                return new HttpActionResult(System.Net.HttpStatusCode.BadRequest, ModelState);
            }

            return await _productosNegocios.CrearProducto(productoDto);
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> PutProduct(int id, ProductoDto productoDto)
        {
            if (!ModelState.IsValid)
            {
                return new HttpActionResult(System.Net.HttpStatusCode.BadRequest, ModelState);
            }

            if(productoDto.Id != id)
            {
                return new HttpActionResult(System.Net.HttpStatusCode.NotFound);
            }

            return await _productosNegocios.Actualizar(productoDto);
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            return await _productosNegocios.EliminarProducto(id);
        }
    }
}