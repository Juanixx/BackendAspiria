using Contratos.Interfaces.Controllers;
using Contratos.Interfaces.Repositorios;
using Contratos.Modelos;
using Negocios.Help;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Negocios.Controllers
{
    public class ProductosNegocios : IProductosNegocios
    {
        IProductosRepositorio _productosRepositorio;

        public ProductosNegocios(IProductosRepositorio productosRepositorio)
        {
            this._productosRepositorio = productosRepositorio;
        }
        public async Task<IHttpActionResult> Actualizar(ProductoDto productoDto)
        {
            Producto producto = await this._productosRepositorio.FindSingleByAsync(x => x.Id == productoDto.Id);

            if(producto == null)
            {
                return new HttpActionResult(HttpStatusCode.NotFound);
            }

            producto.Nombre = productoDto.Nombre;
            producto.Precio = productoDto.Precio;
            producto.RestriccionEdad = productoDto.RestriccionEdad;
            producto.Descripcion = productoDto.Descripcion;
            producto.Compania = productoDto.Compania;

            try
            {
                _productosRepositorio.Edit(producto);
                _productosRepositorio.Save();
            }catch (Exception e)
            {
                Console.WriteLine("Producto no actualizado debido a => " + e.Message);
                return new HttpActionResult(HttpStatusCode.InternalServerError);
            }

            return new HttpActionResult(HttpStatusCode.OK, producto.ToDto());
        }

        public async Task<IHttpActionResult> CrearProducto(ProductoDto productoDto)
        {
            Producto producto = productoDto.ToProducto();

            try
            {
                _productosRepositorio.Add(producto);
                _productosRepositorio.Save();
            }catch(Exception e)
            {
                Console.WriteLine("Producto no creado debido a => " + e.Message);
                return new HttpActionResult(HttpStatusCode.InternalServerError);
            }

            return new HttpActionResult(HttpStatusCode.Created, producto.ToDto());
        }

        public async Task<IHttpActionResult> EliminarProducto(int productoId)
        {
            Producto producto = await _productosRepositorio.FindSingleByAsync(x => x.Id == productoId);
            if(producto == null)
            {
                return new HttpActionResult(HttpStatusCode.NotFound);
            }

            try
            {
                var res = _productosRepositorio.Delete(producto);
                _productosRepositorio.Save();
            }catch(Exception e)
            {
                Console.WriteLine("Producto con id " + productoId + " no eliminado, terminó con error => " + e.Message);
                return new HttpActionResult(HttpStatusCode.InternalServerError);
            }
            return new HttpActionResult(HttpStatusCode.NoContent);
        }

        public async Task<IHttpActionResult> ObtenerProductos()
        {
            return new HttpActionResult(HttpStatusCode.OK, _productosRepositorio.GetAll());
        }
    }
}
