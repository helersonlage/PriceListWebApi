using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Store.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http.Results;


namespace Store.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {

        [TestMethod()]
        public void PostProductTest()
        {
            var mockPrd = GetDemoProduct();
            var mockSet = new Mock<DbSet<Product>>();
            var mockContext = new Mock<StoreEntities>();

            mockContext.Setup(m => m.Products).Returns(mockSet.Object);
            var service = new ProductsController(mockContext.Object);
            var actionResult = service.PostProduct(mockPrd) as CreatedAtRouteNegotiatedContentResult<Product>;

            Assert.IsNotNull(actionResult);

            Assert.AreEqual(actionResult.Content.ID, mockPrd.ID);
            Assert.AreEqual(actionResult.Content.Name, mockPrd.Name);
            Assert.AreEqual(actionResult.Content.Price, mockPrd.Price);
            Assert.AreEqual(actionResult.Content.Discounts.Count, mockPrd.Discounts.Count);


        }


        [TestMethod()]
        public void DeleteProductTest()
        {
           // //int ID = 0;

           // var controller = new ProductsController();
          
           // //Find Prod
           // var product = controller.GetProductByName(new ProductTeste().GetTestProduct().Name) as OkNegotiatedContentResult<Product>;
           // // Save ID tmp
           //// ID = product.Content.ID;
           // //Delete register;
           // var result = controller.DeleteProduct(product.Content.ID) as OkNegotiatedContentResult<Product>;


           // Assert.IsNotNull(result);
           // Assert.AreEqual(product.Content.ID, result.Content.ID);
        }


        Product GetDemoProduct()
        {
            var discount = new Discount { IdProduct = 999, DiscountRate = 10, InitialDate = new System.DateTime(2017, 01, 01, 0, 0, 0), FinalDate = new System.DateTime(2017, 01, 01, 23, 59, 59) };
            var lst = new List<Discount>();
            lst.Add(discount);
            return new Product() { ID = 9999, Name = "teste", Price = 100.00m, Discounts =  lst };
        }



    }
}