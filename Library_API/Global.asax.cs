using Autofac;
using Autofac.Integration.WebApi;
using Library_API.DataAccess;
using System.Reflection;
using System.Web.Http;

namespace Library_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<LibraryService>().As<ILibraryService>();

            var continer = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(continer);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

         
    }
}
