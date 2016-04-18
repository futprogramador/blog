using System;
using System.IO;
using System.Reflection;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;

using NHibernate;

namespace Core.Dados.NH
{
    public static class NhSessionFactory
    {
        private static readonly ISessionFactory _sessionFactory;

        static NhSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                    .Database(
                        MySQLConfiguration.Standard
                        .ConnectionString(
                            builder => builder.FromConnectionStringWithKey("blogConnectionString")))
                    .Mappings(
                        m =>
                        {
                            m.FluentMappings.Conventions.Setup(x => x.Add(AutoImport.Never()));

                            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                            var uri = new UriBuilder(codeBase);
                            var path = Uri.UnescapeDataString(uri.Path);
                            var dirName = Path.GetDirectoryName(path) ?? string.Empty;
                            string[] dlls = Directory.GetFiles(dirName, "*Infra*.dll");
                            foreach (var dll in dlls)
                            {
                                var assembly = Assembly.LoadFrom(dll);
                                m.FluentMappings.AddFromAssembly(assembly);
                            }
                        })
                    .BuildSessionFactory();
        }

        public static ISessionFactory Current
        {
            get
            {
                return _sessionFactory;
            }
        }
    }
}
