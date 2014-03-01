// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISqlDataManager.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The raw data-oriented data manager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.Contract
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// The raw data-oriented data manager interface.
    /// </summary>
    public interface ISqlDataManager
    {
        /// <summary>
        /// The set data source.
        /// </summary>
        /// <param name="dataSource">
        /// The data source.
        /// </param>
        void SetDataSource(string dataSource);

        /// <summary>
        /// The do query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        DataTable DoQuery(string query);

        /// <summary>
        /// The do query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="parameterCollection">
        /// The parameter collection.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        /// <example> 
        /// This example shows how to use <see cref="DoQuery(string, Dictionary{string, object})"/> method. 
        /// <code>
        /// string command = "select * from Customers where city = @City";
        /// <![CDATA[Dictionary<string, object> parameterCollection = new Dictionary<string, object>();]]>
        /// parameterCollection.Add("City", "Dnepropetrovsk");
        /// DataTable dataTable = sqlDataManager.DoQuery(command, parameterCollection);
        /// </code>
        /// </example>
        DataTable DoQuery(string query, Dictionary<string, object> parameterCollection);

        /// <summary>
        /// The get data table.
        /// </summary>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        DataTable GetDataTable(string tableName);

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        void ExecuteCommand(string queryString);

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        void ExecuteCommand(string queryString, string connectionString);

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <param name="parameterCollection">
        /// The parameter collection.
        /// </param>
        void ExecuteCommand(string queryString, Dictionary<string, object> parameterCollection);
    }
}
