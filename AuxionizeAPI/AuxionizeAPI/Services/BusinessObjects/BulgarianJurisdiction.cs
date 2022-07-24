using Auxiomize.Data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auxionize.Common;
using static Auxionize.Common.Enums;
using AuxionizeAPI.DTOs;
using Category = Auxionize.Common.Enums.Category;

namespace AuxionizeAPI.Services.BusinessObjects
{
    public class BulgarianJurisdiction : Jurisdiction
    {
        private string _jurisdiction;

        public BulgarianJurisdiction()
        {
            this._jurisdiction = JurisdictionEnum.Bulgarian.ToString();
        }

        public override string JurisdictionName => _jurisdiction;

        public override int CalculatePercentageVAT(Product product)
        {
            switch (product.CategoryId)
            {
                case (int)Category.Bevarage:
                    return 18;
                case (int)Category.Book:
                    return 7;

                default:
                    return 20;
            }
        }
    }
}
