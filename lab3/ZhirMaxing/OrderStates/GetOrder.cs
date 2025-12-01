namespace ZhirMaxing.OrderStates;

using ZhirMaxing.Observers;

public class GetOrder: IState
{
    private IOrderTracker _orderTracker;
    private IObserverNotifier _observerNotifier; 
    public GetOrder(IOrderTracker orderTracker, IObserverNotifier observerNotifier)
    {
        _orderTracker = orderTracker;
        _observerNotifier = observerNotifier;
        _observerNotifier.Notify("Курьер выехал");
    }
    public void TapScreen()
    {
        _observerNotifier.Notify("Заказ выполнен");
    }
    public void GetAnswer()
    {
        _observerNotifier.Notify("Курьер прибыл, выходите");      
    }
    public string GetStatus() => "Выполнен";
}