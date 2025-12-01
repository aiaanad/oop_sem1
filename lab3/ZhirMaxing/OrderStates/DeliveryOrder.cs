namespace ZhirMaxing.OrderStates;

using ZhirMaxing.Observers;

public class DeliveryOrder: IState
{
    private IOrderTracker _orderTracker;
    private IObserverNotifier _observerNotifier;
    public DeliveryOrder(IOrderTracker orderTracker, IObserverNotifier observerNotifier)
    {
        _orderTracker = orderTracker;
        _observerNotifier = observerNotifier;
        _observerNotifier.Notify("Заказ назначен курьеру");
    }
    public void TapScreen() {
        _observerNotifier.Notify("Заказ доставляется");
        _orderTracker.SetState(new GetOrder(_orderTracker, _observerNotifier));

    }
    public void GetAnswer() {
        _observerNotifier.Notify("Заказ собран!");
    }
    public string GetStatus() => "Доставка";
}