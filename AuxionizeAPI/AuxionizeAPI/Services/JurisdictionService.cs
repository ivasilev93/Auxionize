using Auxiomize.Data.DatabaseModels;
using AuxionizeAPI.DTOs;
using AuxionizeAPI.Services.BusinessObjects;
using AuxionizeAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuxionizeAPI.Services
{
    public class JurisdictionService : IJurisdictionService
    {
        private readonly IJurisdiction _jurisdiction;

        public JurisdictionService(IJurisdiction jurisdiction)
        {
            this._jurisdiction = jurisdiction;
        }

        public string JurisdictionName => _jurisdiction.JurisdictionName;

        public ProductTurnoverBreakdown CalculateGrossTurnover(Product product, decimal grossTurnover)
        {
                int percentageVat = _jurisdiction.CalculatePercentageVAT(product);
                decimal percentage = (decimal)percentageVat / 100;
                decimal netVatAmount = percentage * grossTurnover;
                decimal netTurnover = grossTurnover - netVatAmount;

                var grossTurnoverBreakdown = new ProductTurnoverBreakdown(grossTurnover, netTurnover, percentageVat);

                return grossTurnoverBreakdown;            
        }
    }
}
