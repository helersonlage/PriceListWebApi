using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Models;
using Store.Tests.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Store.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {

        [TestMethod()]
        public void PostProductTest()
        {
            var controller = new ProductsController();
            var item = new ProductTeste().GetTestProduct();
            var result = controller.PostProduct(item) as CreatedAtRouteNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);            
            Assert.AreEqual(result.Content.Name, item.Name);
            Assert.AreEqual(result.Content.Price, item.Price);
        }


        [TestMethod()]
        public void DeleteProductTest()
        {
            //int ID = 0;

            var controller = new ProductsController();
          
            //Find Prod
            var product = controller.GetProductByName(new ProductTeste().GetTestProduct().Name) as OkNegotiatedContentResult<Product>;
            // Save ID tmp
           // ID = product.Content.ID;
            //Delete register;
            var result = controller.DeleteProduct(product.Content.ID) as OkNegotiatedContentResult<Product>;


            Assert.IsNotNull(result);
            Assert.AreEqual(product.Content.ID, result.Content.ID);
        }


    }
}