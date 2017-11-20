using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store;
using Store.Controllers;
using Common;

namespace Store.Tests.Common
{
    [TestClass]
    public class CommonTests
    {
        
        [TestMethod]
        public void RoundDiscountTest()
        {
            IPriceDiscount pDiscount = new PriceRoundDiscount();
            Assert.AreEqual(80, pDiscount.CalcDiscount(rate: 20, price: 100));
            Assert.AreEqual(80, pDiscount.CalcDiscount(rate:20, price:100.005m));
            Assert.AreEqual(100, pDiscount.CalcDiscount(rate: 0, price: 100));
        }


        [TestMethod]
        public void DiscountTest()
        {
            IPriceDiscount pDiscount = new PriceDiscount();
            Assert.AreEqual(80, pDiscount.CalcDiscount(rate: 20, price: 100));
            Assert.AreEqual(80.004m, pDiscount.CalcDiscount(rate: 20, price: 100.005m));
            Assert.AreEqual(100, pDiscount.CalcDiscount(rate: 0, price: 100));
        }


    }
}
