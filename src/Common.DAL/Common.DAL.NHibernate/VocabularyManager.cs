// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VocabularyManager.cs" company="DNU">
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
    using System.Linq;

    using Common.DAL.Contract;
    using Common.DAL.Exception;
    using Common.Domain;

    using global::NHibernate;

    /// <summary>
    /// The ORM data manager.
    /// </summary>
    /// <typeparam name="T">
    /// Type of Entity
    /// </typeparam>
    /// <typeparam name="TK">
    /// Type of Id key
    /// </typeparam>
    public class VocabularyManager<T, TK> : DataManager<T, TK>, IVocabularyManager<T, TK> where T : VocabularyItemBase
    {
        /// <summary>
        /// The get by name. 
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public override T GetByName(string name)
        {
            Type t = typeof(T);
            string typeName = t.Name;
            typeName = typeName.Replace("Base", string.Empty);

            string query = "from " + typeName + " d where d.Description.Name = :name";
            Dictionary<string, object> para = new Dictionary<string, object>();
            para.Add("name", name);

            T result = this.DoQuery(query, para).FirstOrDefault();

            if (result == null)
            {
                ObjectIsNotFoundByNameException objectIsNotFoundByNameException = new ObjectIsNotFoundByNameException();
                objectIsNotFoundByNameException.Data["typeName"] = t.ToString();
                objectIsNotFoundByNameException.Data["name"] = name;
                throw objectIsNotFoundByNameException;
            }

            return result;
        }

        /// <summary>
        /// The save or update. Checks uniqueness of the Description.Name field.
        /// </summary>
        /// <param name="obj">
        /// The object of type T.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public override T SaveOrUpdate(T obj)
        {
            ISession session = this.GetSession();

            if (obj.Id == 0)
            {
                try
                {
                    T existed = this.GetByName(obj.Description.Name);
                    FieldUniquenessViolation fieldUniquenessViolation = new FieldUniquenessViolation("Save or update processing is failed");
                    fieldUniquenessViolation.Data.Add("property", "Description.Name");
                    fieldUniquenessViolation.Data.Add("type", obj.GetType().ToString());
                    throw fieldUniquenessViolation;
                }
                catch (ObjectIsNotFoundByNameException ex)
                {            
                    session.Transaction.Begin();
                    session.SaveOrUpdate(obj);
                    session.Transaction.Commit();
                    session.Flush();
            

                }
            }
            
            return obj;
        }
    }
}
