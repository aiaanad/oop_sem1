namespace ZhirMaxing.OrderStates;

using ZhirMaxing.Observers;

public class CollectOrder: IState
{
    private IOrderTracker _orderTracker;
    private IObserverNotifier _observerNotifier;
    public CollectOrder(IOrderTracker orderTracker, IObserverNotifier observerNotifier)
    {
        _orderTracker = orderTracker;
        _observerNotifier = observerNotifier;
        _observerNotifier.Notify("Началась сборка заказа");
    }
    public void TapScreen()
	{
        _observerNotifier.Notify("Заказ собирается");
        _orderTracker.SetState(new DeliveryOrder(_orderTracker, _observerNotifier));
	}
	public void GetAnswer()
	{
		_observerNotifier.Notify("Заказ создан!");
	}
    public string GetStatus() => "Подготовка";
}