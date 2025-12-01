namespace ZhirMaxing.OrderStates;

public interface IState
{
    void TapScreen();
    void GetAnswer();
    string GetStatus();
}