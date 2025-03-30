using BAL;
using DAL.DbContextEntity;
using Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace WebUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ProductDbContext>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IProductServices, ProductServices>();
            container.RegisterType<ICategoryServices, CategoryServices>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}