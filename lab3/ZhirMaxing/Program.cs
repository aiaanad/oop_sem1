using ZhirMaxing.OrderStates;
using ZhirMaxing.Builders;
using ZhirMaxing.Models;
using ZhirMaxing.Observers;
using ZhirMaxing.Data;
using ZhirMaxing.Strategies;
using ZhirMaxing.Interfaces;
using ZhirMaxing.Services;


namespace ZhirMaxing;

public class Program
{
    public static void Main(string[] args)
    {
        var user1 = new User(1);
        var dishBuilder = new DishBuilder();
        var pizza = dishBuilder.SetName("Pizza").SetPrice(100).Build();
        var shawerma = dishBuilder.SetName("Shawerma").SetPrice(200).Build();

        var menuBuilder = new MenuBuilder();
        var menu = menuBuilder.SetName("Letnee").AddDishes(new List<IDish> { pizza, shawerma }).Build();

        var orderManagment = new OrderManagment(menu, user1);
        var myDeliveryType = DeliveryType.Express;
        orderManagment.SetDeliveryType(myDeliveryType);
        orderManagment.DisplayMenu();
        orderManagment.AddDishWithId(1);
        orderManagment.DoOrder();
        orderManagment.StartTrack();
        orderManagment.StateInfo();
        orderManagment.GoNextState();
        orderManagment.StateInfo();
        orderManagment.GoNextState();
        orderManagment.StateInfo();
        orderManagment.GetStatus();
        
        //var orderB = new OrderBuilder(calcS);

        //// Создаем блюдо через DishBuilder
        //var dishBuilder = new DishBuilder();
        //var dish = dishBuilder
        //    .SetName("pizza")
        //    .SetPrice(100)
        //    .Build();

        //var order = orderB
        //    .SetUserId(1)
        //    .AddDish(dish)
        //    .SetDeliveryType(DeliveryType.Base)
        //    .Build();

        //var observerN = new ObserverNotifier(order);
        //observerN.Attach(user1);

        //// Передаем заказ в трекер
        //var orderTracker = new OrderTracker(observerN);
        //orderTracker.GetAnswer();
        //orderTracker.TapScreen();
        //orderTracker.GetAnswer();
        //orderTracker.TapScreen();
        //orderTracker.GetAnswer();
        //orderTracker.TapScreen();
        //orderTracker.GetAnswer();
    }
}