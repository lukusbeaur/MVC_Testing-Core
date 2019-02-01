using System.Collections.Generic;

namespace MVCtesting.Model
{
        public interface IRepository
        {
            IEnumerable<Products> Product { get; }
            void AddProducts(Products P);
        }   
}
