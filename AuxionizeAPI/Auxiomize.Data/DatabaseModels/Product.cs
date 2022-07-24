using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auxiomize.Data.DatabaseModels
{
    public class Product : BaseEntity
    {
        public Product(string Name, decimal Price, string EAN, int CategoryId)
        {
            this.Name = Name;
            this.Price = Price;
            this.EAN = EAN;
            this.CategoryId = CategoryId;
        }

        public string EAN { get; protected set; } //I though about making EAN primary key, but this makes EAN column immutable/not easy to upade if it is wrong input 
        public decimal Price { get; protected set; }
        public string Name { get; protected set; }
        public int CategoryId { get; protected set; }
        public Category Category { get; protected set; }
    }
}
