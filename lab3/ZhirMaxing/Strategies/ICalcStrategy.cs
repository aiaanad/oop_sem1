namespace ZhirMaxing.Strategies;

using ZhirMaxing.Interfaces;

public interface ICalcStrategy
{
    decimal CalculatePrice(decimal price);
}