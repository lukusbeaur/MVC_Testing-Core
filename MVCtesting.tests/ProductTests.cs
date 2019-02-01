using System;
using MVCtesting.Model;
using Xunit;

namespace MVCtesting.tests
{
    public class ProductTests
    {
        [Fact]
        public void canChangeProductName()
        {
            //arrange
            var p = new Products
            {
                Name = "test",
                Price = 100M
            };
            //act
            p.Name = "New Name";

            //assert
            Assert.Equal("New Name", p.Name);
        }
        [Fact]
        public void canChangeProductPrice()
        {
            //arrange
            var p = new Products
            {
                Name = "test",
                Price = 100M
            };
            p.Price = 200M;
            Assert.Equal(200M, p.Price);
        }
    }
}
