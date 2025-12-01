namespace ZhirMaxing.OrderStates;

public interface IOrderTracker
{
    void TapScreen();
    void GetAnswer();
    string GetStatus();
    void SetState(IState state);
}