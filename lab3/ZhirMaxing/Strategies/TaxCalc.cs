namespace ZhirMaxing.Strategies;

using ZhirMaxing.Interfaces;

public class TaxCalc : ICalcStrategy
{
	private int _tax;

	public TaxCalc(int tax)
	{
		_tax = tax;
	}
	public decimal CalculatePrice(decimal price) => price * (1 + _tax / 100);
	
}