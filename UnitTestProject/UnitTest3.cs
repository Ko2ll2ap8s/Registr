using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp16;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var page = new AuthPage();
            Assert.IsTrue(page.Auth("Letha241", "00A84"));
            Assert.IsTrue(page.Auth("Mollie1975", "8"));
            Assert.IsTrue(page.Auth("Woodrow2009", "NO40J"));
            Assert.IsFalse(page.Auth("Chrisopher1976", "I15457"));
            
        }
    }
}
