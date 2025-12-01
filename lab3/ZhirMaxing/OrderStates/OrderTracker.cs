namespace ZhirMaxing.OrderStates;

using ZhirMaxing.Observers;
using ZhirMaxing.Interfaces;

public class OrderTracker : IOrderTracker
{
    private IOrder _order;
    private IState _state;
    private string _status;
    private IObserverNotifier _observerNotifier;

    public OrderTracker(IObserverNotifier observerNotifier)
    {
        SetState(new CollectOrder(this, observerNotifier));
    }

    public void SetState(IState state) {
        _state = state;
        Console.WriteLine($"Статус изменён");
    } 
    public string GetStatus() => _state.GetStatus();

    public void TapScreen() => _state.TapScreen();
    
    public void GetAnswer() => _state.GetAnswer();
    
}