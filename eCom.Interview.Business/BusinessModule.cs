using System.Reflection;
using Autofac;
using Module = Autofac.Module;
using eCom.Interview.Contracts;

namespace eCom.Interview.Business
{
    public class BusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            builder.RegisterType<EmailTemplateBL>().As<IEmailTemplateBL>().InstancePerLifetimeScope();
        }
    }
}
