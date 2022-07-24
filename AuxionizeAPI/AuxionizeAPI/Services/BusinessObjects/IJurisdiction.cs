using Auxiomize.Data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuxionizeAPI.Services.BusinessObjects
{
    public interface IJurisdiction
    {
        public abstract string JurisdictionName { get; }
        public abstract int CalculatePercentageVAT(Product product);
    }
}
