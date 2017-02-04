using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ПочекунLibrary;
using System.Threading;

namespace PochekunLibraryTests
{
    [TestClass]
    public class БезвізовийРежимTests
    {
        DateTime безвізовийРежимExpectedTime;

        [TestInitialize]
        public void БезвізовийРежимTestsInit()
        {
            безвізовийРежимExpectedTime = new DateTime(2017, 04, 30);
        }

        [TestMethod]
        public void ПеремогаTest()
        {
            var почекун = Україна.Instance.ПочекатиБезвізовийРежим();
            if (безвізовийРежимExpectedTime > DateTime.Now)
            {
                Thread.Sleep(безвізовийРежимExpectedTime - DateTime.Now);
            }
            Assert.IsTrue(почекун.IsCompleted);
            var безвізовийРежим = почекун.Result;
            Assert.IsNotNull(безвізовийРежим);
            безвізовийРежим.ПоїхалиВBiedronka();
        }

        [TestMethod]
        public void ЗрадаTest()
        {
            var почекун = Україна.Instance.ПочекатиБезвізовийРежим();
            if (безвізовийРежимExpectedTime > DateTime.Now)
            {
                Thread.Sleep(безвізовийРежимExpectedTime - DateTime.Now);
            }
            Assert.IsFalse(почекун.IsCompleted);
        }
    }
}
