namespace ZhirMaxing.Services;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Strategies;

public interface IPricingService
{
    void AddStrategy(ICalcStrategy strategy);
    bool RemoveStrategy(ICalcStrategy strategy);
    decimal CalculatePrice(decimal dishesTotal);
}