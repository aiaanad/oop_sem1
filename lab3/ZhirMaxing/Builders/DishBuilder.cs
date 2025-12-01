namespace ZhirMaxing.Builders;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Services;
using ZhirMaxing.Data;
using ZhirMaxing.Models;

public class DishBuilder : IDishBuilder
{
    private string _name;
    private decimal _price;
    private static int _id = 1;
    public IDishBuilder SetName(string name) {
        _name = name;
        return this;
    }
    public IDishBuilder SetPrice(decimal price)
    {
        _price = price;
        return this;    
    }

    public string GetName() => _name;
    public decimal GetPrice() => _price;

    public IDish Build()
    {
        if (_price == null) throw new ArgumentNullException();
        if (_name == null) throw new ArgumentNullException();

        var newDish = new Dish(_id, _name, _price);
        _id++;
        return newDish;
    }
}