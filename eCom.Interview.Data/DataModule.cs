using Autofac;
using eCom.Interview.Web;
using eComEngine.Interview.Data;
using System.Reflection;
using Module = Autofac.Module;
using eCom.Interview.DTO;

namespace eCom.Interview.Data
{
    public class DataModule : Module
    {      
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            builder.RegisterType<EmailTemplateXmlFileRepository>().As<IRepository<EmailTemplate>>();
            builder.Register(ctx =>
            {
                //var address = "C:\\Users\\Jr\\Source\\Repos\\ecom.interview\\eCom.Interview.Data\\Data\\Templates.xml";
                var address = ApplicationSettings.TemplateFilePath;
                return new EmailTemplateXmlFileRepository(address);
            }).As<IRepository<EmailTemplate>>();


        }
    }
}
