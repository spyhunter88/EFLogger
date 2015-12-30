using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger.Example;
using FrameLog;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Logger.Example.Models;
using FrameLog.Models;
using Repository.Pattern.Infrastructure;

namespace Logger.Tests
{
    [TestClass]
    public class BasicTest
    {
        #region Properties
        ExampleContext context;
        LoggerModule loggerModule;
        private string connectionString = "ExampleContext";
        #endregion

        [TestInitialize]
        public void Initialize()
        {
            context = new ExampleContext();
            ContextInfo contextInfo = new ContextInfo(((IObjectContextAdapter)context).ObjectContext);
            contextInfo.UnderlyingType = typeof(ExampleContext);
            loggerModule = new LoggerModule(connectionString, contextInfo, 1);

            // Should inject using Unity instead of set
            context.Logger = loggerModule;
        }

        // [TestMethod]
        public void AddWithManualPrimaryKey()
        {
            Customer customer = new Customer
            {
                CustomerID = "AAAAA",
                CompanyName = "TTM",
                ContactTitle = "Admin",
                ContactName = "Hoai Linh",
                Address = "1 Dai Co Viet",
                City = "HN",
                Country = "VN",
                Fax = "0000-000-000",
                Phone = "1111-111-111",
                Region = "KA",
                PostalCode = "10000"
            };

            customer.ObjectState = ObjectState.Added;

            // Add to database
            context.Customers.Add(customer);
            context.SaveChanges();

            ChangeSet cs = loggerModule.ChangeSet;

            Assert.IsNotNull(cs);
        }

        [TestMethod]
        public void AddWithDatabaseGeneratedPrimaryKey()
        {
            Category category = new Category
            {
                Code = "TEST",
                Type = "TEST",
                Value = "SAMPLE",
                Description = "Test with database generated key!",
                ObjectState = ObjectState.Added
            };

            // Add
            context.Categories.Add(category);
            context.SaveChanges();

            ChangeSet cs = loggerModule.ChangeSet;

            Assert.IsNotNull(cs);
        }

        // [TestMethod]
        public void Edit()
        {
            Category category = context.Categories
                                    .Where(x => x.Code == "TEST")
                                    .FirstOrDefault();
            if (category == null) return;

            Random rand = new Random(1000);
            category.Value = "SAMPLE" + rand.Next();
            category.ObjectState = ObjectState.Modified;

            context.SaveChanges();

            ChangeSet cs = loggerModule.ChangeSet;

            Assert.IsNotNull(cs);
        }

        [TestMethod]
        public void Delete()
        {
            Category category = context.Categories
                                    .Where(x => x.Code == "TEST")
                                    .FirstOrDefault();
            if (category == null) return;
            category.ObjectState = ObjectState.Deleted;

            context.SaveChanges();
            ChangeSet cs = loggerModule.ChangeSet;

            Assert.IsNotNull(cs);
        }

        [TestCleanup]
        public void Cleanup()
        {

        }
    }
}
