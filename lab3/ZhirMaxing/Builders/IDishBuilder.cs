namespace ZhirMaxing.Builders;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Services;
using ZhirMaxing.Data;

public interface IDishBuilder
{
    IDishBuilder SetName(string name);
    IDishBuilder SetPrice(decimal price);

    string GetName();
    decimal GetPrice();

    IDish Build();
}