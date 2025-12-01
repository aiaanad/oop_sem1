namespace ZhirMaxing.Builders;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Services;
using ZhirMaxing.Data;

public interface IMenuBuilder
{
    IMenuBuilder SetName(string name);
    IMenuBuilder AddDish(IDish dish);
    IMenuBuilder AddDishes(List<IDish> dishes);
    IMenuBuilder RemoveDish(IDish dish);

    string GetName();

    IMenu Build();
}