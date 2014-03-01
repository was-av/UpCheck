// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataManager.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The ORM data manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.NHibernate
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Common.DAL.Contract;

    using global::NHibernate;

    using global::NHibernate.Criterion;

    using global::NHibernate.Linq;

    /// <summary>
    /// The ORM data manager.
    /// </summary>
    /// <typeparam name="T">
    /// Type of Entity
    /// </typeparam>
    /// <typeparam name="TK">
    /// Type of Id key
    /// </typeparam>
    public class DataManager<T, TK> : IDataManager<T, TK>
    {
        /// <summary>
        /// The type metadata of T.
        /// </summary>
        private readonly Type type = typeof(T); 

        /// <summary>
        /// The configuration file name.
        /// </summary>
        private string configFileName = string.Empty;

        /// <summary>
        /// Gets or sets the configuration file name.
        /// </summary>
        protected string ConfigFileName
        {
            get { return this.configFileName; }
            set { this.configFileName = value; }
        }

        /// <summary>
        /// Get object by Id.
        /// </summary>
        /// <param name="id">
        /// Id key.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="HibernateException">
        /// Hibernate exception
        /// </exception>
        public virtual T Get(TK id) 
        {
            // Говорим что возвращаем тип T и загружаем его используя сессию через метод Load
            T result = (T)this.GetSession().Load(this.type, id); 
            return result;
        }

        /// <summary>
        /// The get by name. 
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public virtual T GetByName(string name)
        {
            Type t = typeof(T);
            string typeName = t.Name;
            typeName = typeName.Replace("Base", string.Empty);

            string query = "from " + typeName + " d where d.Description.Name = :name";
            Dictionary<string, object> para = new Dictionary<string, object>();
            para.Add("name", name);

            T result = this.DoQuery(query, para).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// The get all objects of defined type. Used when we are working with vocabulary.
        /// </summary>
        /// <returns>
        /// The <see>
        ///       <cref>IList</cref>
        ///     </see> .
        /// </returns>
        public virtual IList<T> GetAll()
        {
            IList<T> list = this.GetAll(0, 0);
            return list;
        }

        /// <summary>
        /// The get by criteria. NHibernate-oriented method.
        /// </summary>
        /// <param name="criterion">
        /// The criterion.
        /// </param>
        /// <returns>
        /// The <see>
        ///       <cref>List</cref>
        ///     </see> .
        /// </returns>
        public virtual List<T> GetByCriteria(params ICriterion[] criterion)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(this.type);

            foreach (ICriterion criterium in criterion)
            {
                criteria.Add(criterium);
            }

            return criteria.List<T>() as List<T>;
        }

        /// <summary>
        /// The get by criteria.
        /// </summary>
        /// <param name="startIndex">
        /// The start index.
        /// </param>
        /// <param name="maximumObjects">
        /// The maximum objects.
        /// </param>
        /// <param name="criterion">
        /// The criterion.
        /// </param>
        /// <returns>
        /// The <see>
        ///       <cref>List</cref>
        ///     </see> .
        /// </returns>
        public virtual List<T> GetByCriteria(int startIndex, int maximumObjects, params ICriterion[] criterion)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(this.type);
            criteria.SetFirstResult(startIndex);
            criteria.SetMaxResults(maximumObjects);

            foreach (ICriterion criterium in criterion)
            {
                criteria.Add(criterium);
            }

            return criteria.List<T>() as List<T>;
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="obj">
        /// The object of type T.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="HibernateException">
        /// Hibernate exception.
        /// </exception>
        public virtual T Save(T obj)
        {
            try
            {
                this.GetSession().Transaction.Begin();
                this.GetSession().Save(obj);
                this.GetSession().Transaction.Commit();

                return obj;
            }
            catch (HibernateException)
            {
                this.GetSession().Transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// The save or update.
        /// </summary>
        /// <param name="obj">
        /// The object of type T.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public virtual T SaveOrUpdate(T obj)
        {
            ISession session = this.GetSession();

            session.Transaction.Begin();
            session.SaveOrUpdate(obj);
            session.Transaction.Commit();

            session.Flush();

            return obj;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="obj">
        /// The object from database.
        /// </param>
        /// <exception cref="HibernateException">
        /// Hibernate Exception
        /// </exception>
        public virtual void Delete(T obj)
        {
            ISession session = this.GetSession();

            try
            {
                session.Transaction.Begin();
                session.Delete(obj);
                session.Transaction.Commit();

                session.Flush();
            }
            catch (HibernateException)
            {
                this.GetSession().Transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// The do query.
        /// </summary>
        /// <param name="linqExpression">
        /// The linq expression.
        /// </param>
        /// <returns>
        /// The list of T <see>
        ///                 <cref>IList</cref>
        ///               </see> .
        /// </returns>
        /// <example>        
        /// <code>
        ///    <![CDATA[System.Linq.Expressions.Expression<Func<MemberBase, bool>> stateExpression = null;]]>
        ///    stateExpression = m => m.PersonalInfo.Address.StateId == 27;    
        ///    T result = this.DoQuery(stateExpression).FirstOrDefault();
        /// </code>
        /// </example>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public IList<T> DoQuery(System.Linq.Expressions.Expression<Func<T, bool>> linqExpression)
        {
            IList<T> collection = this.GetSession().Query<T>().Where(linqExpression).ToList();
            return collection;
        }

        /// <summary>
        /// The do query.
        /// </summary>
        /// <param name="queryText">
        /// The query text.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The list of T <see>
        ///       <cref>IList</cref>
        ///     </see> .
        /// </returns>
        /// <exception cref="HibernateException">
        /// Hibernate Exception
        /// </exception>
        /// <example>
        ///    string name = "John";
        ///    string query = "from " + typeName + " d where d.Description.Name = :name";
        ///    <![CDATA[Dictionary<string, object> para = new Dictionary<string, object>();]]>
        ///    para.Add("name", name);
        ///    T result = this.DoQuery(query, para).FirstOrDefault();
        /// </example>
        public virtual IList<T> DoQuery(string queryText, Dictionary<string, object> parameters)
        {
            ISession session = this.GetSession();

            IQuery query = session.CreateQuery(queryText);

            foreach (var parameter in parameters)
            {
                KeyValuePair<string, object> kv = parameter;
                query.SetParameter(kv.Key, kv.Value);
            }

            IList<T> result = query.List<T>();
                
            return result;
        }

        /// <summary>
        /// The do query.
        /// </summary>
        /// <param name="queryText">
        /// The query text.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <param name="startIndex">
        /// The start index.
        /// </param>
        /// <param name="maximumObjects">
        /// The maximum objects.
        /// </param>
        /// <returns>
        /// The <see>
        ///       <cref>IList</cref>
        ///     </see> .
        /// </returns>
        /// <exception cref="HibernateException">
        /// Hibernate Exception
        /// </exception>
        public virtual IList<T> DoQuery(string queryText, Dictionary<string, object> parameters, int startIndex, int maximumObjects)
        {
            ISession session = this.GetSession();

            IQuery query = session.CreateQuery(queryText).SetFirstResult(startIndex).SetMaxResults(maximumObjects);

            foreach (var parameter in parameters)
            {
                KeyValuePair<string, object> kv = parameter;
                query.SetParameter(kv.Key, kv.Value);
            }

            IList<T> result = query.List<T>();
            return result;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The <see>
        ///       <cref>IList</cref>
        ///     </see> .
        /// </returns>
        public virtual IList<T> GetAll(int pageIndex, int pageSize)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(T));
            criteria.SetFirstResult(pageIndex * pageSize);

            if (pageSize > 0)
            {
                criteria.SetMaxResults(pageSize);
            }

            return criteria.List<T>();
        }

        /// <summary>
        /// The get session method.
        /// </summary>
        /// <returns>
        /// The <see cref="ISession"/>.
        /// </returns>
        protected ISession GetSession()
        {
            if (this.ConfigFileName.Equals(string.Empty))
            {
                return SessionFactory.GetSession(); 
            }

            return SessionFactory.GetSession(this.ConfigFileName);
        }
    }
}
