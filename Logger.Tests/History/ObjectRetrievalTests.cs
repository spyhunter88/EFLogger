using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests.History
{
    [TestClass]
    public class ObjectRetrievalTests : HistoryExplorerTests
    {
        public ObjectRetrievalTests() : base() { }


        [TestMethod]
        public void CanRetrieveObjectChangeDefault()
        {
            var category = context.Categories.Where(c => c.CategoryID == 59)
                            .FirstOrDefault();

            var val = historyExplorer.ChangesTo(category);
            var actual = val.First().ObjectChange;
        }
    }
}
