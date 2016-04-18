using System.Reflection;
using System.Web.Mvc;

using Aplicacao;

using Core;
using Core.Dados.NH;
using Core.Dados.UnitOfWork;

using Dominio.Repositorios;

using Infraestrutura;
using Infraestrutura.Repositorios;

using Servicos.Contratos;
using Servicos.Contratos.Impl;

using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace Web
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = Bootstrapper.Container;

            //RegistrarValidators();
            RegistrarTiposcompartilhados();
            RegistrarApplicationsServices();
            RegistrarServicosExternos();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();            
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegistrarTiposcompartilhados()
        {
            var container = Bootstrapper.Container;

            // Registra sessão do NHibernate
            container.Register(() => NhSessionFactory.Current.OpenSession(), new SimpleInjector.Integration.Web.WebRequestLifestyle());

            container.Register(typeof(INHSession), typeof(NHSession));

            //Registra Repositório genérico
            container.Register(typeof(IRepositorio<>), typeof(Repositorio<>));

            //Registra Unit Of work Factory
            container.Register(typeof(IUnitOfWorkFactory), typeof(UnitOfWorkFactory));

            //Automapper
            //container.RegisterSingleton(() => Mapper.Engine);
            //Mapper.Initialize(p =>
            //{
            //    p.AddProfile(new ButProfile());
            //    p.AddProfile(new WebApiProfile());
            //});

            //Mapper.AssertConfigurationIsValid();
        }

        private static void RegistrarApplicationsServices()
        {
            var container = Bootstrapper.Container;            
            container.Register<IPostFacade, PostFacade>();            
        }

        //private static void RegistrarValidators()
        //{
        //    var container = Bootstrapper.Container;
        //    container.Register<IValidator<PedidoPostModel>, PedidoPostValidator>();
        //    container.Register<IValidator<PedidoPutModel>, PedidoPutValidator>();
        //}

        private static void RegistrarServicosExternos()
        {
            var container = Bootstrapper.Container;

            //container.Register<IServicoWSScrubber, ServicoWSScrubber>();

            //container.Register(() =>
            //{
            //    var factory = new ChannelFactory<IWSScrubber>("WSScrubberEndPoint");
            //    var channel = factory.CreateChannel();
            //    return channel;
            //});
        }
    }
}