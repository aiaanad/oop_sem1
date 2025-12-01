namespace ZhirMaxing.Strategies;

using ZhirMaxing.Interfaces;

public class BaseCalc : ICalcStrategy
{
    public decimal CalculatePrice(decimal price) => price;
}