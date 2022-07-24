using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuxionizeAPI.DTOs
{
    public class ProductTurnoverBreakdown
    {
        public ProductTurnoverBreakdown(decimal grossTurnover, decimal netTurnover, int vat)
        {
            GrossTurnover = grossTurnover;
            NetTurnover = netTurnover;
            VAT = vat;
        }

        public decimal GrossTurnover { get; private set; }
        public decimal NetTurnover { get; private set; }
        public int VAT { get; private set; }
    }
}
