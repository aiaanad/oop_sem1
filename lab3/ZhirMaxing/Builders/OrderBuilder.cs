namespace ZhirMaxing.Builders;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Services;
using ZhirMaxing.Data;
using ZhirMaxing.Strategies;
using ZhirMaxing.Models;

public class OrderBuilder: IOrderBuilder
{
    private int _userId;
    private static int _id = 1;
    private IPricingService _pricingService;
    private List<IDish> _dishes = new List<IDish>();
    private DeliveryType _deliveryType;
    private string? _userWishes;
    private decimal _price;

    public OrderBuilder(IPricingService pricingService)
    {
        _pricingService = pricingService;
    }

    public IOrderBuilder SetUserId(int userId)
    {
        _userId = userId;
        return this;
    }

    public IOrderBuilder AddDish(IDish dish)
    {
        _dishes.Add(dish);
        return this;
    }

    public IOrderBuilder RemoveDish(IDish dish)
    {
        _dishes.Remove(dish);
        return this;
    }
    public bool HasDish(IDish dish) => _dishes.Contains(dish);
    

    public IOrderBuilder SetDeliveryType(DeliveryType deliveryType)
    {
        _deliveryType = deliveryType;
        return this;
    }

    public IOrderBuilder SetUserWishes(string userWishes)
    {
        _userWishes = userWishes;
        return this;
    }

    private decimal GetDeliveryPrice()
    {
        return _deliveryType switch
        {
            DeliveryType.Base => 300m,
            DeliveryType.Express => 500m,
            _ => throw new ArgumentException()
        };
    }

    private decimal CalculateTotalPrice() => _pricingService.CalculatePrice(_price);
  

    public IOrder Build()
    {
        if (_userId == 0) throw new ArgumentNullException();
        if (!_dishes.Any()) throw new ArgumentNullException();

        if (_price == null) _price = _dishes.Select(d => d.Price).Sum();
        _price = CalculateTotalPrice();
        _price += GetDeliveryPrice();

        var newOrder = new Order(_id, _userId, _dishes, _deliveryType, _userWishes, _price);
        _id++;
        return newOrder;
    }
}