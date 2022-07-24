using Auxiomize.Data;
using Auxiomize.Data.DatabaseModels;
using Auxionize.Common;
using AuxionizeAPI.DTOs;
using AuxionizeAPI.Services;
using AuxionizeAPI.Services.BusinessObjects;
using AuxionizeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuxionizeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMemoryCache(options =>
            {
                options.SizeLimit = Constants.CACHE_SIZE_LIMIT;
            });

            //this depends on how are we gonna choose when and what jurisdiction to choose. 
            services.AddScoped<IJurisdiction, BulgarianJurisdiction>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IJurisdictionService, JurisdictionService>();

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AuxionizeDatabaseConnectionString")));

            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
            //populate cache on startup since... well memory cache...
            LoadCache(app);
        }

        private void LoadCache(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                var dbContext = serviceProvider.GetService<DatabaseContext>();
                var cache = serviceProvider.GetService<IMemoryCache>();

                var records = dbContext.GrossTurnoverByProduct;
                foreach (var record in records)
                {
                    ProductTurnoverBreakdown breakdown = new ProductTurnoverBreakdown(record.GrossTurnover, record.NetTurnover, record.PercentageVAT);

                    cache.Set(
                        record.ProductEAN,
                        breakdown,
                        new MemoryCacheEntryOptions {
                            Size = Constants.CACHE_ENTRY_SLIDING_EXPIRATION_DAY,
                            SlidingExpiration = TimeSpan.FromDays(Constants.CACHE_ENTRY_SLIDING_EXPIRATION_DAY)
                        });
                }

            }            
        }
    }
}
