using Contratos.Interfaces.Controllers;
using Contratos.Interfaces.Repositorios;
using Negocios.Controllers;
using Negocios.NegociosRepositorios;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace EjercicioAspiriaBack
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IProductosNegocios, ProductosNegocios>();

            container.RegisterType<IProductosRepositorio, ProductosRepositorio>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}