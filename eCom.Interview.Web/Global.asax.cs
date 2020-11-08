using Autofac;
using eCom.Interview.Business;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using eCom.Interview.Data;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Reflection;

namespace eCom.Interview.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new BusinessModule());
            builder.RegisterModule(new DataModule());        

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            IoC.Container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(IoC.Container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(IoC.Container));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetApplicationSettings();
        }

        private void SetApplicationSettings()
        {
            ApplicationSettings.TemplateFilePath = System.Configuration.ConfigurationManager.AppSettings["TemplateFilePath"];
            ApplicationSettings.DefaultPageSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DefaultPageSize"]);
        }
    }
}
