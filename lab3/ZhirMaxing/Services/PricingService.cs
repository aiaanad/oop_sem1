namespace ZhirMaxing.Services;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Strategies;

public class PricingService : IPricingService
{
    private readonly List<ICalcStrategy> _strategies = new List<ICalcStrategy>();

    public void AddStrategy(ICalcStrategy strategy) => _strategies.Add(strategy);
    public bool RemoveStrategy(ICalcStrategy strategy) => _strategies.Remove(strategy);

    public decimal CalculatePrice(decimal dishesTotal)
    {
        decimal total = dishesTotal;
        foreach (var strategy in _strategies) {
            total = strategy.CalculatePrice(dishesTotal);
        }
        return total;
    }
}