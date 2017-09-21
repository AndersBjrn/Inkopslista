using NHibernate;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Inkopslista.Mapping;
using NHibernate.Dialect;
using NHibernate.Cfg;



namespace WebApplication2.Services
{
    public class DbService
    {
        public static Configuration Configure()
        {
            Configuration cfg = new Configuration()
                           .DataBaseIntegration(db =>
                           {
                               db.ConnectionString = @"Server = (localdb)\mssqllocaldb; Database = Inkopslista; Trusted_Connection = True;";
                               db.Dialect<MsSql2008Dialect>();
                           });

            var mapper = new ModelMapper();
            Type[] myTypes = Assembly.GetExecutingAssembly().GetExportedTypes();
            mapper.AddMappings(myTypes);

            HbmMapping mapping = new NHibernateMapper().Map();
            cfg.AddMapping(mapping);

            return cfg;
        }

        public static ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = Configure().BuildSessionFactory();
            }
            ISession session = _sessionFactory.OpenSession();
            session.BeginTransaction();
            return session;
        }

        public static void CloseSession(ISession session)
        {
            if (session != null)
            {
                if (session.IsOpen)
                {
                    session.Transaction.Commit();
                    session.Close();
                }
            }
        }

        private static ISessionFactory _sessionFactory;

    }
}