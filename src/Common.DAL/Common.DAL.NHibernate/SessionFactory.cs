// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionFactory.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The NHibernate session factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.NHibernate
{
    using System.Runtime.Remoting.Messaging;

    using global::NHibernate;

    using global::NHibernate.Cfg;

    /// <summary>
    /// The NHibernate session factory.
    /// </summary>
    public class SessionFactory
    {
        /// <summary>
        /// The transaction key.
        /// </summary>
        private const string TransactionKey = "CONTEXT_TRANSACTION";

        /// <summary>
        /// The session key.
        /// </summary>
        private const string SessionKey = "CONTEXT_SESSION";

        /// <summary>
        /// The session factory.
        /// </summary>
        private static ISessionFactory sessionFactory;

        /// <summary>
        /// Gets or sets the context session.
        /// </summary>
        private static ISession ContextSession 
        {
            get
            {
                // Сессию мы храним в контексте, вот так работать с контекстом
                return (ISession)CallContext.GetData(SessionKey);
            }

            set
            {
                CallContext.SetData(SessionKey, value);
            }
        }

        /// <summary>
        /// Gets or sets the context transaction.
        /// </summary>
        private static ITransaction ContextTransaction
        {
            get
            {
                return (ITransaction)CallContext.GetData(TransactionKey);
            }

            set
            {
                CallContext.SetData(TransactionKey, value);
            }
        }

        /// <summary>
        /// The initialization of factory.
        /// </summary>
        public static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();

            Configuration cfg = new Configuration();
            sessionFactory = cfg.Configure().BuildSessionFactory();
        }

        /// <summary>
        /// The initialization of factory.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        public static void Init(string fileName)
        {
            log4net.Config.XmlConfigurator.Configure();

            Configuration cfg = new Configuration();
            sessionFactory = cfg.Configure(fileName).BuildSessionFactory();
        }

        /// <summary>
        /// The get session.
        /// </summary>
        /// <returns>
        /// The <see cref="ISession"/>.
        /// </returns>
        public static ISession GetSession()
        {
            ISession session = ContextSession;
            Init();
            if (session == null)
            {
                session = sessionFactory.OpenSession();
                ContextSession = session;
            }

            return session;
        }

        /// <summary>
        /// The get session.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="ISession"/>.
        /// </returns>
        public static ISession GetSession(string fileName)
        {
            ISession session = ContextSession;
            Init(fileName);
            if (session == null)
            {
                session = sessionFactory.OpenSession();
                ContextSession = session;
            }

            return session;
        }

        /// <summary>
        /// The close session.
        /// </summary>
        public static void CloseSession()
        {
            ISession session = ContextSession;

            if (session != null && session.IsOpen)
            {
                session.Flush();
                session.Close();
            }

            ContextSession = null;
        }

        /// <summary>
        /// The begin transaction.
        /// </summary>
        public static void BeginTransaction()
        {
            ITransaction transaction = ContextTransaction;

            if (transaction == null)
            {
                transaction = GetSession().BeginTransaction();
                ContextTransaction = transaction;
            }
        }

        /// <summary>
        /// The commit transaction.
        /// </summary>
        public static void CommitTransaction()
        {
            ITransaction transaction = ContextTransaction;

            try
            {
                if (HasOpenTransaction())
                {
                    transaction.Commit();
                    ContextTransaction = null;
                }
            }
            catch (HibernateException)
            {
                RollbackTransaction();
                throw;
            }
        }

        /// <summary>
        /// The has open transaction.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool HasOpenTransaction()
        {
            ITransaction transaction = ContextTransaction;

            return transaction != null && !transaction.WasCommitted && !transaction.WasRolledBack;
        }

        /// <summary>
        /// The rollback transaction.
        /// </summary>
        public static void RollbackTransaction()
        {
            ITransaction transaction = ContextTransaction;

            try
            {
                if (HasOpenTransaction())
                {
                    transaction.Rollback();
                }

                ContextTransaction = null;
            }
            finally
            {
                CloseSession();
            }
        }
    }
}
