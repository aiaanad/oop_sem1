namespace ZhirMaxing.Models;

using ZhirMaxing.Interfaces;

public class Dish : IDish
{
    private int _id;
    private string _name;
    private decimal _price;

    public Dish(int id, string name, decimal price)
    {
        _id = id;
        _name = name;
        _price = price;
    }
    public int Id => _id;
    public string Name => _name;
    public decimal Price => _price;
    public string GetDescription() => $"Name: {_name}, Price: {_price}";
}
