namespace ZhirMaxing.Services;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Data;
using ZhirMaxing.Builders;
using ZhirMaxing.Strategies;
using ZhirMaxing.Observers;
using ZhirMaxing.OrderStates;
using ZhirMaxing.Models;
using ZhirMaxing.Strategies;

public class OrderManagment : IOrderManagment
{
    private User _user;
    private IOrder _order;
    private IPricingService _pricingService;
    private IOrderBuilder _orderBuilder;
    private IMenu _menu;
    private IMenuDisplayer _menuDisplayer;
    private IChoicingService _choicingService;
    private IOrderTracker _orderTracker;
    private IObserverNotifier _observerNotifier;

    public OrderManagment(IMenu menu, User user)
    {
        _user = user;
        _pricingService = new PricingService();
        _pricingService.AddStrategy(new BaseCalc());

        _orderBuilder = new OrderBuilder(_pricingService);
        _orderBuilder.SetUserId(_user.UserId);
        _menu = menu;
        _menuDisplayer = new MenuDisplayer(_menu);
        _choicingService = new ChoicingService(_menu);
        _observerNotifier = new ObserverNotifier();
        _orderTracker = new OrderTracker(_observerNotifier);
    }

    public void DisplayMenu()
    {
        Console.WriteLine(_menuDisplayer.DisplayMenu());
    }
    public void AddDishWithId(int id)
    {
        if (_choicingService.IsCorrect(id))
        {
            var dish = _choicingService.GetDishWithId(id);
            _orderBuilder = _orderBuilder.AddDish(dish);
        }
        else throw new ArgumentException();
        
    }
    public void RemoveDishWithId(int id)
    {
        if (_choicingService.IsCorrect(id))
        {
            var dish = _choicingService.GetDishWithId(id);
            if (_orderBuilder.HasDish(dish))
            {
                _orderBuilder.AddDish(dish);
            }
            else throw new Exception();
        }
        else throw new ArgumentException();
    }
    public void SetDeliveryType(DeliveryType deliveryType)
    {
        _orderBuilder.SetDeliveryType(deliveryType);
    }
    public void SayWishes(string wishes)
    {
        _orderBuilder.SetUserWishes(wishes);
    }
    public void UseDiscount(int discount)
    {
        var newStrategy = new DiscountCalc(discount);
        _pricingService.AddStrategy(newStrategy);

    }
    public void DoOrder()
    {
        try
        {
            _order = _orderBuilder.Build();
        }
        catch
        {
            throw new Exception();
        }
        
    }
    public void StartTrack()
    {
        if (_orderTracker == null) throw new Exception();
        _observerNotifier.Attach(_user);
    }
    public void StateInfo()
    {
        if (_orderTracker == null) throw new Exception();
        
        _orderTracker.GetAnswer();
    }
    public void GoNextState()
    {
        if (_orderTracker == null) throw new Exception();
        _orderTracker.TapScreen();
    }
    public void GetStatus()
    {
        if (_orderTracker == null) throw new Exception();
        Console.WriteLine(_orderTracker.GetStatus());
    }
    public void EndTrack()
    {
        if (_orderTracker == null) throw new Exception();
        _observerNotifier.Detach(_user);
    }
}