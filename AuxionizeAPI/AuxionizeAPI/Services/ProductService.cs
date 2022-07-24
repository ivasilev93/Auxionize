using AuxionizeAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auxionize.Common;
using Auxiomize.Data;
using Microsoft.Extensions.Logging;
using Auxiomize.Data.DatabaseModels;
using AuxionizeAPI.Services.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using AuxionizeAPI.Services.Interfaces;

namespace AuxionizeAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly DatabaseContext _dbContext;

        public ProductService(DatabaseContext dbcontext, ILogger<ProductService> logger)
        {
            this._dbContext = dbcontext;
            this._logger = logger;
        }

        public ValidationResult Validate(ProductTurnover model)
        {
            if (string.IsNullOrEmpty(model.Name))
                return new ValidationResult("Product name cannot be empty");

            if (!Constants.EAN_Regex.IsMatch(model.EAN))
                return new ValidationResult("Product EAN must be between 8 and 13 digits");

            if (model.GrossTurnover < 0)
                return new ValidationResult("Invalid product gross turnover");

            return new ValidationResult();
        }

        public async Task<Product> GetByEAN(string ean)
        {
            try
            {
                var product = await _dbContext.Products.FirstAsync(x => x.EAN == ean);
                return product;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }      

        public async Task AddGrossTurnoverByProduct(ProductTurnoverBreakdown product, string productEan, string jurisdiction)
        {
            try
            {
                var grossTurnoverByProduct = new GrossTurnoverByProduct(productEan, product.VAT, product.NetTurnover, product.GrossTurnover, jurisdiction);

                await _dbContext.GrossTurnoverByProduct.AddAsync(grossTurnoverByProduct);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }
    }
}
