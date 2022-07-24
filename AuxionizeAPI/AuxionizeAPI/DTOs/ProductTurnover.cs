using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuxionizeAPI.DTOs
{
    public class ProductTurnover
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string EAN { get; set; }
        public int GrossTurnover { get; set; }
    }
}
