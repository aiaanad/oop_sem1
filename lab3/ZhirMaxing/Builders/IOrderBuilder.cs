namespace ZhirMaxing.Builders;

using ZhirMaxing.Interfaces;
using ZhirMaxing.Services;
using ZhirMaxing.Data;

public interface IOrderBuilder
{
    IOrderBuilder SetUserId(int userId);
    IOrderBuilder AddDish(IDish dish);
    IOrderBuilder RemoveDish(IDish dish);
    bool HasDish(IDish dish);
    IOrderBuilder SetDeliveryType(DeliveryType deliveryType);
    IOrderBuilder SetUserWishes(string wishes);

    IOrder Build();
}