using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auxiomize.Data.DatabaseModels
{
    public class GrossTurnoverByProduct : BaseEntity
    {
        public GrossTurnoverByProduct(string ProductEAN, int PercentageVAT, decimal NetTurnover, decimal GrossTurnover, string Jurisdiction)
        {
            this.ProductEAN = ProductEAN;
            this.PercentageVAT = PercentageVAT;
            this.NetTurnover = NetTurnover;
            this.GrossTurnover = GrossTurnover;
            this.Jurisdiction = Jurisdiction;
        }

        public string ProductEAN { get; protected set; }
        public int PercentageVAT { get; protected set; }
        public decimal NetTurnover { get; protected set; }
        public decimal GrossTurnover { get; protected set; }
        public string Jurisdiction { get; protected set; }
    }
}
