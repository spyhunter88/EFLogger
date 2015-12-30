using System.Linq;
using FrameLog;
using Logger.Example;
using Logger.Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Pattern.Infrastructure;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Logger.Tests
{
    [TestClass]
    public class ReferenceTest
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
        public void AddWithReference()
        {
            Requirement requirement = new Requirement
            {
                Name = "TEST01",
                Operation = "Greater",
                Target = 1000,
                ObjectState = ObjectState.Added
            };

            Claim claim = new Claim
            {
                ProgramName = "TEST",
                BuName = "FAP",
                ClaimItem = "Notebook",
                StatusID = 1,
                UnitClaim = "F5",
                ClaimType = "Money",
                CurrencyUnit = "USD",
                VendorName = "ASUS",
                FtgProgramCode = "ASUS.15_999",
                ParticipantClaim = "1",
                ProductLine = "All",
                ProgramType = "Rebate",
                StartDate = DateTime.Now.AddDays(-12D),
                EndDate = DateTime.Now.AddDays(40),
                ObjectState = ObjectState.Added
            };

            claim.Requirements.Add(requirement);

            context.Claims.Add(claim);
            context.SaveChanges();

            Assert.IsNotNull(loggerModule.ChangeSet);
        }

        [TestMethod]
        public void AddReference()
        {
            Claim claim = context.Claims
                        .Where(x => x.ProgramName == "TEST")
                        .Include(x => x.Requirements)
                        .FirstOrDefault();

            Requirement requirement = new Requirement
            {
                Name = "TEST03",
                Operation = "Greater",
                Target = 1000,
                ObjectState = ObjectState.Added
            };

            claim.Requirements.Add(requirement);
            claim.ObjectState = ObjectState.Modified;
            
            context.SaveChanges();

            Assert.IsNotNull(loggerModule.ChangeSet);
        }


        // [TestMethod]
        public void EditReference()
        {

        }

        // [TestMethod]
        public void EditReferenceProperty()
        {

        }

        // [TestMethod]
        public void DeleteReference()
        {

        }
    }
}
