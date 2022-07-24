using Auxiomize.Data.DatabaseModels;
using AuxionizeAPI.DTOs;
using AuxionizeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuxionizeAPI.Services.Interfaces;
using Auxionize.Common;

namespace AuxionizeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IJurisdictionService _jurisdictionService;
        private readonly IMemoryCache _memoryCache;

        public ProductsController(IProductService productService, IMemoryCache memoryCache, IJurisdictionService jurisdictionService)
        {
            _productService = productService;
            _memoryCache = memoryCache;
            _jurisdictionService = jurisdictionService;
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<ProductTurnoverBreakdown>> Product([FromBody] ProductTurnover model)
        {
            // validate input
            Services.BusinessObjects.ValidationResult validation = _productService.Validate(model);
            if (!validation.Success)
                return BadRequest(validation.Message);

            Product product = null;

            //lookup in cache for calculation by EAN
            ProductTurnoverBreakdown grossTurnoverBreakdown = null;
            if (!_memoryCache.TryGetValue(model.EAN, out grossTurnoverBreakdown))
            {
                //get product from db by EAN
                product = await _productService.GetByEAN(model.EAN);

                //calculate vat / create response
                grossTurnoverBreakdown = _jurisdictionService.CalculateGrossTurnover(product, model.GrossTurnover);

                if (grossTurnoverBreakdown == null)
                    return BadRequest();

                //insert to db
                await _productService.AddGrossTurnoverByProduct(grossTurnoverBreakdown, product.EAN, _jurisdictionService.JurisdictionName);

                _memoryCache.Set(
                    product.EAN,
                    grossTurnoverBreakdown, 
                    new MemoryCacheEntryOptions
                    {
                        Size = Constants.CACHE_ENTRY_SLIDING_EXPIRATION_DAY,
                        SlidingExpiration = TimeSpan.FromDays(Constants.CACHE_ENTRY_SLIDING_EXPIRATION_DAY)
                    });

                return Ok(grossTurnoverBreakdown);
            }
            else
            {
                return Ok(grossTurnoverBreakdown);
            }
        }
    }
}
