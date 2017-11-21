using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Store.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
            // Arrange
            var mockPrd = GetDemoProduct();
            var mockRepository = new Mock<DbSet<Product>>();
            var mockContext = new Mock<StoreEntities>();
            mockContext.Setup(m => m.Products).Returns(mockRepository.Object);
            var controller = new ProductsController(mockContext.Object);

            // Action 
            var actionResult = controller.PostProduct(mockPrd) as CreatedAtRouteNegotiatedContentResult<Product>;

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.Content.ID, mockPrd.ID);
            Assert.AreEqual(actionResult.Content.Name, mockPrd.Name);
            Assert.AreEqual(actionResult.Content.Price, mockPrd.Price);
            Assert.AreEqual(actionResult.Content.Discounts.Count, mockPrd.Discounts.Count);

        }


        [TestMethod()]
        public void DeleteProductTest()
        {

            // Arrange
            var data = GetListProduct();

            var mockRepository = new Mock<DbSet<Product>>();
            mockRepository.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockRepository.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockRepository.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockRepository.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<StoreEntities>();
            mockContext.Setup(c => c.Products).Returns(mockRepository.Object);
            var controller = new ProductsController(mockContext.Object);

            // Action 
            var productDeleted = controller.DeleteProduct(2) as OkNegotiatedContentResult<Product>;

            //Assert
            Assert.AreEqual(productDeleted.Content.ID, 2);
        }


        [TestMethod()]
        public void GetALLProductTest()
        {

            // Arrange
            var data = GetListProduct();

            var mockRepository = new Mock<DbSet<Product>>();
            mockRepository.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockRepository.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockRepository.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockRepository.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<StoreEntities>();
            mockContext.Setup(c => c.Products).Returns(mockRepository.Object);
            var controller = new ProductsController(mockContext.Object);

            // Action 
            var productGetAll = controller.GetProducts() as OkNegotiatedContentResult<List<Product>>;

            //Assert
            Assert.AreEqual(productGetAll.Content.Count(), 5);
        }


        [TestMethod()]
        public void PutProductTest()
        {
            // Arrange
            var mockPrd = GetDemoProduct();
            var mockRepository = new Mock<DbSet<Product>>();
            var mockContext = new Mock<StoreEntities>();
            mockContext.Setup(m => m.Products).Returns(mockRepository.Object);
            var controller = new ProductsController(mockContext.Object);

            // Action 
            var actionResult = controller.PutProduct(999, mockPrd) as StatusCodeResult;

            //Assert
            Assert.AreEqual(actionResult.StatusCode,System.Net.HttpStatusCode.NoContent);
           

        }


        Product GetDemoProduct()
        {
            var discount = new Discount { IdProduct = 999, DiscountRate = 10, InitialDate = new System.DateTime(2017, 01, 01, 0, 0, 0), FinalDate = new System.DateTime(2017, 01, 01, 23, 59, 59) };
            var lst = new List<Discount>();
            lst.Add(discount);
            return new Product() { ID = 999, Name = "Product Test", Price = 100.00m, Discounts = lst };
        }

        IQueryable<Product> GetListProduct()
        {
            var data = new List<Product>
            {
                new Product { ID = 1, Name = "test1", Price = 99 },
                new Product { ID = 2, Name = "test2", Price = 98 },
                new Product { ID = 3, Name = "test3", Price = 97 },
                new Product { ID = 4, Name = "test3", Price = 96 },
                new Product { ID = 5, Name = "test5", Price = 95 }

            }.AsQueryable();

            return data;
        }

    }
}