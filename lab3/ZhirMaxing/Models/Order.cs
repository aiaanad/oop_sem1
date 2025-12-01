namespace ZhirMaxing.Models;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Data;

public class Order : IOrder
{
    private readonly int _id;
    private readonly int _userId;
    private List<IDish> _dishes = new List<IDish>();
    private DeliveryType _deliveryType;
    private string? _userWishes;
    private decimal _price;

    public Order(int id, int userId, List<IDish> dishes, DeliveryType deliveryType, string userWishes, decimal price)
    {
        _id = id;
        _userId = userId;
        _dishes = dishes;
        _deliveryType = deliveryType;
        _userWishes = userWishes;
        _price = price;
    }
    public int Id => _id;
    public int UserId => _userId;
    public List<IDish> Dishes => _dishes;
    public DeliveryType GetDeliveryType => _deliveryType;
    public string? UserWishes => _userWishes;
    public decimal Price => _price;
    
}

