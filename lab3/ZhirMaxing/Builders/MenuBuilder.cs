namespace ZhirMaxing.Builders;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Services;
using ZhirMaxing.Data;
using ZhirMaxing.Models;

public class MenuBuilder : IMenuBuilder
{
    private static int _id = 1;
    private string _name;
    private List<IDish> _dishes = new List<IDish>();

    public IMenuBuilder SetName(string name) {
        _name = name;
        return this;
    }

    public IMenuBuilder AddDish(IDish dish) {
        _dishes.Add(dish);
        return this;
    } 
    public IMenuBuilder AddDishes(List<IDish> dishes) {
        if (!dishes.Any()) throw new ArgumentNullException();
        foreach (var  dish in dishes) { 
            _dishes.Add(dish); 
        } 
        return this;
    }
    public IMenuBuilder RemoveDish(IDish dish){
        _dishes.Remove(dish);
        return this;
    }

    public string GetName() => _name;

    public IMenu Build()
    {
        if (_name == null) throw new ArgumentNullException();
        if (!_dishes.Any()) throw new ArgumentNullException();
        var newMenu = new Menu(_name, _id, _dishes);
        _id++;
        return newMenu;
    }
}