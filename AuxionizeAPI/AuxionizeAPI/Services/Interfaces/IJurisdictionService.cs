using Auxiomize.Data.DatabaseModels;
using AuxionizeAPI.DTOs;

namespace AuxionizeAPI.Services.Interfaces
{
    public interface IJurisdictionService
    {
        string JurisdictionName { get; }
        ProductTurnoverBreakdown CalculateGrossTurnover(Product product, decimal grossTurnover);
    }
}