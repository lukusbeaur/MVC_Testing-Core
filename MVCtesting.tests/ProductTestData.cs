using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MVCtesting.Model;

namespace MVCtesting.tests
{
    class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetPriceLT50() };
            yield return new object[] { GetPriceGTET50 };
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private IEnumerable<Products> GetPriceLT50()
        {
            decimal[] prices = new decimal[]
            {
                275, 50, 25, 35
            };
            for (int i = 0; i < prices.Length; i++)
            {
                yield return new Products
                {
                    Name = $"P{i + 1}",
                    Price = prices[i]
                };
            }
        }
        private Products[] GetPriceGTET50 => new Products[]
        {
            new Products {Name = "P1", Price = 275},
            new Products {Name = "P2", Price = 50},
            new Products {Name = "P3", Price = 25},
            new Products {Name = "P4", Price = 35}
        };
    }
}
