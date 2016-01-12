using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameLog;
using FrameLog.Contexts;
using FrameLog.History;
using FrameLog.Models;
using Logger.Example;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests.History
{
    [TestClass]
    public class HistoryExplorerTests
    {
        #region Properties
        protected ExampleContext context;
        protected HistoryContext historyContext;
        protected HistoryExplorer<ChangeSet, User> historyExplorer;

        private string connectionString = "ExampleContext";
        #endregion

        [TestInitialize]
        public void Initialize()
        {
            context = new ExampleContext();
            ContextInfo contextInfo = new ContextInfo(((IObjectContextAdapter)context).ObjectContext);
            contextInfo.UnderlyingType = typeof(ExampleContext);
            historyContext = new HistoryContext(connectionString);

            historyContext.ContextInfo = contextInfo;

            historyExplorer = new HistoryExplorer<ChangeSet, User>(historyContext);
        }

        protected void check<T>(T value, User author, IChange<T, User> change,
                   Func<T, T, bool> equalityCheck = null, Func<T, string> formatter = null)
        {
            equalityCheck = equalityCheck ?? EqualityComparer<T>.Default.Equals;
            formatter = formatter ?? defaultFormatter;

            Assert.IsTrue(equalityCheck(value, change.Value),
                string.Format("Values were not equal. Expected: '{0}'. Actual: '{1}'",
                formatter(value), formatter(change.Value)));
            Assert.AreEqual(author, change.Author);
            TestHelpers.IsRecent(change.Timestamp, TimeSpan.FromSeconds(5));
        }
        private string defaultFormatter<T>(T x)
        {
            if (x != null)
                return x.ToString();
            else
                return "<null>";
        }
    }
}
