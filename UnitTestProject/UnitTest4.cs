using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp16;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void RegistrationTestSuccess()
        {
            var page = new RegPage();
            Assert.IsTrue(page.Registr("Егорик", "12345", "12345", "Чутик Егор Александрович"));
            Assert.IsFalse(page.Registr("Винни Пух", "NO40J", "757575", "Мёдович Медведь Косолапович"));
        }
    }
}
