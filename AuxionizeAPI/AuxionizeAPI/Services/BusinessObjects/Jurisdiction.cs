using Auxiomize.Data.DatabaseModels;
using AuxionizeAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxionizeAPI.Services.BusinessObjects
{
    public abstract class Jurisdiction : IJurisdiction
    {
        public abstract string JurisdictionName { get; }
        public abstract int CalculatePercentageVAT(Product product);
    }
}
