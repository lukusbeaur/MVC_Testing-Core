using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MVCtesting.Model;
using MVCtesting.Controllers.Controllers;
using Xunit;
using Moq;

namespace MVCtesting.tests
{
    public class HomeControllerTest
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Products> Product { get; set; }
            public void AddProducts(Products p)
            {
                //doNothing : not required for testing, but needs to be present for overload
            }
        }
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void  IndexActionModelIsComplete(Products[] products)
        {
            //arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Product).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            //act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Products>;

            //assert
            Assert.Equal(controller.Repository.Product, model,
                        Comparer.Get<Products>((p1, p2) => 
                        //p1.Name == p2.Name &&
                        p1.Price == p2.Price));
        }

        [Fact]
        public void RepositoryCalledOnce()
        {
            //arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Product).Returns(new[]
            {
                new Products
                {
                    Name = "P1", Price = 100
                }
            });
            var controller = new HomeController
            {
                Repository = mock.Object
            };
            //Act
            var result = controller.Index();
            //Assert
            mock.VerifyGet(m => m.Product, Times.Once);
        }
    }
}
