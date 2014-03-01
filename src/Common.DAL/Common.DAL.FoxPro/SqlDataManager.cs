// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlDataManager.cs" company="DNU">
//   
// </copyright>
// <summary>
//   The low level data manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.FoxPro
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;

    using Common.DAL.Contract;
    using Common.DAL.Exception;

    /// <summary>
    /// The low level data manager.
    /// </summary>
    public class SqlDataManager : ISqlDataManager
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private string connectionString = @"provider=VFPOLEDB.1; data source= '{0}';password='';user id=''";

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return this.connectionString;
            }

            set
            {
                this.connectionString = value;
            }
        }

        /// <summary>
        /// The set data source.
        /// </summary>
        /// <param name="dataSource">
        /// The data source.
        /// </param>
        public void SetDataSource(string dataSource)
        {
            this.connectionString = string.Format(this.connectionString, dataSource);
        }

        /// <summary>
        /// The do query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        public DataTable DoQuery(string query)
        {
            return this.DoQuery(query, new Dictionary<string, object>());
        }

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
        /// string command = "select * from Customers where city = @City";
        /// Dictionary<string, object> parameterCollection = new Dictionary<string, object>();
        /// parameterCollection.Add("City", "Dnepropetrovsk");
        /// DataTable dataTable = sqlDataManager.DoQuery(command, parameterCollection);
        /// </example>
        public DataTable DoQuery(string query, Dictionary<string, object> parameterCollection)
        {
            DataTable dataTable = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(this.connectionString))
            {
                connection.Open();

                OleDbCommand queryCommand = new OleDbCommand(query, connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
               
                foreach (KeyValuePair<string, object> kvp in parameterCollection)
                {
                    OleDbParameter param = new OleDbParameter();
                    param.ParameterName = "@" + kvp.Key;
                    param.Value = kvp.Value;
                    queryCommand.Parameters.Add(param);
                }

                adapter.SelectCommand = queryCommand;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// The get data table.
        /// </summary>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        public DataTable GetDataTable(string tableName)
        {
            try
            {
                DataTable dataTable = new DataTable();

                OleDbConnection oleDbConnection = new OleDbConnection(this.ConnectionString);

                oleDbConnection.Open();

                if (oleDbConnection.State == ConnectionState.Open)
                {
                    OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter("select * from " + tableName, oleDbConnection);
                    oleDbDataAdapter.Fill(dataTable);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                GetDataTableException getDataTableException = new GetDataTableException("Get data table failed", ex);
                getDataTableException.Data.Add("table", tableName);
                getDataTableException.Data.Add("connection", this.ConnectionString);
                throw getDataTableException;
            }
        }

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        public void ExecuteCommand(string queryString)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(this.connectionString))
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        public void ExecuteCommand(string queryString, string connectionString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <param name="parameterCollection">
        /// The parameter collection.
        /// </param>
        public void ExecuteCommand(string queryString, Dictionary<string, object> parameterCollection)
        {
            using (OleDbConnection connection = new OleDbConnection(this.connectionString))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(queryString, connection);

                foreach (KeyValuePair<string, object> kvp in parameterCollection)
                {
                    OleDbParameter param = new OleDbParameter();         
                    param.ParameterName = "@" + kvp.Key;
                    param.Value = kvp.Value;
                    command.Parameters.Add(param);
                }

                command.ExecuteNonQuery();
            }
        }
    }
}
