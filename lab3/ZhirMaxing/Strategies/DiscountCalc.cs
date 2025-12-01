namespace ZhirMaxing.Strategies;

using ZhirMaxing.Interfaces;

public class DiscountCalc : ICalcStrategy
{
    private int _discount;

    public DiscountCalc(int discount)
    {
        _discount = discount;
    }

    public decimal CalculatePrice(decimal price) => price * (1 - _discount / 100);
     
}