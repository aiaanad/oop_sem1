namespace ZhirMaxing.Services;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Data;

public interface IOrderManagment
{
    void DisplayMenu();
    void AddDishWithId(int id);
    void RemoveDishWithId(int id);
    void SetDeliveryType(DeliveryType deliveryType);
    void SayWishes(string wishes);
    void UseDiscount(int discount);
    void DoOrder();
    void StartTrack();
    void StateInfo();
    void GoNextState();
    void GetStatus();
    void EndTrack();
}