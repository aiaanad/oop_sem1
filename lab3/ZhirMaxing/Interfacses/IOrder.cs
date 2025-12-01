namespace ZhirMaxing.Interfaces;

using ZhirMaxing.OrderStates;
using ZhirMaxing.Data;

public interface IOrder
{
    int Id { get; }
    int UserId {  get; }
    List<IDish> Dishes { get; }
    DeliveryType GetDeliveryType { get; }
    string? UserWishes { get; }
    decimal Price { get; }
}
