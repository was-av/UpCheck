// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataManager.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The object relation mapping data manager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    /// <summary>
    /// The object relation mapping data manager interface.
    /// </summary>
    /// <typeparam name="T">
    /// Entity type
    /// </typeparam>
    /// <typeparam name="TK">
    /// Key Id
    /// </typeparam>
    public interface IDataManager<T, TK>
        {
            /// <summary>
            /// Get object by Id.
            /// </summary>
            /// <param name="id">
            /// Id key.
            /// </param>
            /// <returns>
            /// The <see cref="T"/>.
            /// </returns>
            T Get(TK id);

            /// <summary>
            /// The get by name. 
            /// </summary>
            /// <param name="name">
            /// The name.
            /// </param>
            /// <returns>
            /// The <see cref="T"/>.
            /// </returns>
            T GetByName(string name);

            /// <summary>
            /// The get all objects of defined type. Used when we are working with vocabulary.
            /// </summary>
            /// <returns>
            /// The <see cref="IList{T}"/>.
            /// </returns>
            IList<T> GetAll();

            /// <summary>
            /// The save.
            /// </summary>
            /// <param name="obj">
            /// The object of type T.
            /// </param>
            /// <returns>
            /// The <see cref="T"/>.
            /// </returns>
            T Save(T obj);

            /// <summary>
            /// The save or update.
            /// </summary>
            /// <param name="obj">
            /// The object of type T.
            /// </param>
            /// <returns>
            /// The <see cref="T"/>.
            /// </returns>
            T SaveOrUpdate(T obj);

            /// <summary>
            /// The delete.
            /// </summary>
            /// <param name="obj">
            /// The object from database.
            /// </param>
            void Delete(T obj);

            /// <summary>
            /// The do query function.
            /// </summary>
            /// <param name="linqExpression"> 
            /// linq Expression
            /// </param>
            /// <returns>
            /// The <see cref="IList{T}"/>.
            /// </returns>
            /// <example>
            /// This example shows how to use <see cref="DoQuery(string, Dictionary{string, object})"/> method in NHibernate realization.
            /// <code>
            ///    <![CDATA[System.Linq.Expressions.Expression<Func<MemberBase, bool>> stateExpression = null;]]>
            ///    stateExpression = m => m.PersonalInfo.Address.StateId == 27;    
            ///    T result = this.DoQuery(stateExpression).FirstOrDefault();
            /// </code>
            /// </example>
            [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
            IList<T> DoQuery(Expression<Func<T, bool>> linqExpression);

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
            /// The <see cref="IList{T}"/>.
            /// </returns>
            /// <example>
            /// This example shows how to use <see cref="DoQuery(string, Dictionary{string, object})"/> method in NHibernate realization.
            /// <code>
            ///    string name = "Vasya";
            ///    string query = "from " + typeName + " d where d.Description.Name = :name";
            ///    <![CDATA[Dictionary<string, object> para = new Dictionary<string, object>();]]>
            ///    para.Add("name", name);
            ///    T result = this.DoQuery(query, para).FirstOrDefault();
            /// </code>
            /// </example>
            IList<T> DoQuery(string queryText, Dictionary<string, object> parameters);

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
            /// The <see cref="IList{T}"/>.
            /// </returns>
            IList<T> DoQuery(string queryText, Dictionary<string, object> parameters, int startIndex, int maximumObjects);
        }
}
