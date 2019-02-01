using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCtesting.Model
{
    public class SimpleRepository : IRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();

        private Dictionary<string, Products> products = new Dictionary<string, Products>();


        public static SimpleRepository SharedRepository => sharedRepository;

        public SimpleRepository()
        {
            var initialItems = new[]
            {
                new Products { Name = "Kayak" , Price = 275M},
                new Products { Name = "LifeJacket", Price = 50M},
                new Products { Name = "Soccer Ball", Price = 25M },
                new Products { Name = "Life Jacker", Price = 35M}
            };
            foreach (var p in initialItems)
            {
                AddProducts(p);
            }
        }

        public IEnumerable<Products> Product => products.Values;
        public void AddProducts(Products p) => products.Add(p.Name, p);
        
    }
}
