using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auxiomize.Data.DatabaseModels
{
    public class Category : BaseEntity
    {
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; protected set; }
    }
}
