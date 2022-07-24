using Auxiomize.Data.DatabaseModels;
using AuxionizeAPI.DTOs;
using AuxionizeAPI.Services.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuxionizeAPI.Services.Interfaces
{
    public interface IProductService
    {
        ValidationResult Validate(ProductTurnover model);

        Task<Product> GetByEAN(string ean);
        Task AddGrossTurnoverByProduct(ProductTurnoverBreakdown product, string productEan, string jurisdiction);
    }
}
