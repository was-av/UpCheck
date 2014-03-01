// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataManagerTester.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the DataManagerTester type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq.Expressions;

    using Common.DAL.Contract;
    using Common.DAL.Test.Domain;
    using Common.Domain;
    using Common.Utility.Unity;

    using NUnit.Framework;

    /// <summary>
    /// The data manager tester.
    /// </summary>
    [TestFixture]
    public class DataManagerTester
    {
        /// <summary>
        /// The state manager.
        /// </summary>
        private IDataManager<StateBase, int> stateManager;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.stateManager = TypeController.Instance.GetObjectOfType<IDataManager<StateBase, int>>();
        }

        /// <summary>
        /// The new.
        /// </summary>
        [Test]
        public void New()
        {
            StateBase state = TypeController.Instance.GetObjectOfType<StateBase>();
            DescriptionBase description = TypeController.Instance.GetObjectOfType<DescriptionBase>();
            description.Description = "Россия";
            description.Name = "Russia";
            description.Name1 = "Россия";
            state.Description = description;

            this.stateManager.SaveOrUpdate(state);
            Assert.IsTrue(state.Id > 0);
            Console.Write(state.Id);
        }

        /// <summary>
        /// The do query.
        /// </summary>
        [Test]
        public void DoQueryTest()
        {
            Type type = typeof(StateBase);
            Debug.Assert(type.FullName != null, "type.FullName != null");

            string typeName = type.FullName.Replace("Base", string.Empty);
            typeName = typeName.Replace("Domain", "Domain.Default");
            string queryText = "from " + typeName + " d where d.Description.Name = :name";
            Dictionary<string, object> queryData = new Dictionary<string, object> { { "name", "Ukraine" } };

            IList<StateBase> stateCollection = this.stateManager.DoQuery(queryText, queryData);

            foreach (StateBase state in stateCollection)
            {
                Console.WriteLine(state.Description.Description);
            }
        }

        /// <summary>
        /// The do query.
        /// </summary>
        [Test]
        public void DoLinqQueryTest()
        {
            Expression<Func<StateBase, bool>> stateExpression = m => m.Description.Description == "Ukraine";   
 
            IList<StateBase> stateCollection = this.stateManager.DoQuery(stateExpression);

            foreach (StateBase state in stateCollection)
            {
                Console.WriteLine(state.Description.Description);
            }
        }
    }
}
