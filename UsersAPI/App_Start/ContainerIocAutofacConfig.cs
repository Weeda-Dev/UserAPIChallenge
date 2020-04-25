using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using UsersAPI.Interfaces;
using UsersAPI.Services;

namespace UsersAPI
{
    public class ContainerIocAutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Register all Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Register dependencies
            builder.RegisterType<GetIdService>().As<IGetIdService>().SingleInstance();
            builder.RegisterType<GetJsonFileDataService>().As<IGetJsonFileDataService>().SingleInstance();
            builder.RegisterType<GetUsersService>().As<IGetUsersService>().SingleInstance();
            builder.RegisterType<GetValidInputService>().As<IGetValidInputService>().SingleInstance();
            builder.RegisterType<GetFilePathService>().As<IGetFilePathService>().SingleInstance();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}