// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlDataManagerTester.cs" company="">
//   
// </copyright>
// <summary>
//   The sql data manager tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.Test
{
    using System;
    using System.Data;
    using Common.DAL.Contract;
    using Common.DAL.Exception;
    using Common.Utility.Unity;

    using NUnit.Framework;

    /// <summary>
    /// The sql data manager tester.
    /// </summary>
    [TestFixture]
    public class SqlDataManagerTester
    {
        /// <summary>
        /// The sql-oriented data manager realization.
        /// </summary>
        private ISqlDataManager sqlDataManager;

        /// <summary>
        /// Set up test bunch.
        /// </summary>
        [SetUp]
        public void Init()
        {
            this.sqlDataManager = TypeController.Instance.GetObjectOfType<ISqlDataManager>();
        }

        /// <summary>
        /// The get all test. 
        /// Preconditions: 
        ///     - install Foxpro driver 
        ///     - check the project is 0x86-oriented
        ///     - check the folder is created
        ///     - check if table exists
        /// </summary>
        [Test]
        public void GetAllTest()
        {
            this.sqlDataManager.SetDataSource(@"C:\ambcser\baza");
            DataTable dataTable = this.sqlDataManager.GetDataTable("p_cntry");
            Assert.IsTrue(dataTable.Rows.Count > 0);
        }

        /// <summary>
        /// The get all test fail.
        /// </summary>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [TestCase("pp_cntry", ExpectedException = typeof(GetDataTableException))]
        public int GetAllTestFail(string tableName)
        {
            try
            {
                this.sqlDataManager.SetDataSource(@"C:\ambcser\baza");
                DataTable dataTable = this.sqlDataManager.GetDataTable(tableName);
                return dataTable.Rows.Count;
            }
            catch (GetDataTableException ex)
            {
                string message = ex.GetMessage();
                Console.WriteLine(message);
                throw;
            }
        }
    }
}
