namespace ZhirMaxing.Observers;

using ZhirMaxing.Interfaces;

public interface IObserverNotifier
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string message);
}