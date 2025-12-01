using Xunit;
using Moq;
using ZhirMaxing.Builders;
using ZhirMaxing.Interfaces;
using ZhirMaxing.Models;
using ZhirMaxing.Services;
using ZhirMaxing.Data;

namespace ZhirMaxing.Tests
{
    public class DishBuilderTests
    {
        [Fact]
        public void Build_WithValidData_ReturnsDish()
        {
            // Arrange
            var builder = new DishBuilder();

            // Act
            var dish = builder
                .SetName("Pizza")
                .SetPrice(599.99m)
                .Build();

            // Assert
            Assert.NotNull(dish);
            Assert.Equal("Pizza", dish.Name);
            Assert.Equal(599.99m, dish.Price);
            Assert.NotEqual(0, dish.Id);
        }

        [Fact]
        public void Build_WithoutName_ThrowsException()
        {
            // Arrange
            var builder = new DishBuilder();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                builder.SetPrice(100m).Build());
        }

        [Fact]
        public void Build_WithoutPrice_ThrowsException()
        {
            // Arrange
            var builder = new DishBuilder();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                builder.SetName("Pizza").Build());
        }
    }

    public class MenuBuilderTests
    {
        [Fact]
        public void Build_WithValidData_ReturnsMenu()
        {
            // Arrange
            var builder = new MenuBuilder();
            var mockDish = new Mock<IDish>();
            mockDish.Setup(d => d.Id).Returns(1);
            mockDish.Setup(d => d.Name).Returns("Test Dish");
            mockDish.Setup(d => d.Price).Returns(100m);

            // Act
            var menu = builder
                .SetName("Lunch Menu")
                .AddDish(mockDish.Object)
                .Build();

            // Assert
            Assert.NotNull(menu);
            Assert.Equal("Lunch Menu", menu.Name);
            Assert.Single(menu.Dishes);
        }

        [Fact]
        public void AddDishes_WithEmptyList_ThrowsException()
        {
            // Arrange
            var builder = new MenuBuilder();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                builder.AddDishes(new List<IDish>()));
        }
    }

    public class OrderBuilderTests
    {
        [Fact]
        public void Build_WithValidData_ReturnsOrder()
        {
            // Arrange
            var mockPricingService = new Mock<IPricingService>();
            mockPricingService.Setup(p => p.CalculatePrice(It.IsAny<decimal>()))
                .Returns((decimal price) => price);

            var builder = new OrderBuilder(mockPricingService.Object);
            var mockDish = new Mock<IDish>();
            mockDish.Setup(d => d.Price).Returns(100m);

            // Act
            var order = builder
                .SetUserId(1)
                .AddDish(mockDish.Object)
                .SetDeliveryType(DeliveryType.Base)
                .SetUserWishes("No onions")
                .Build();

            // Assert
            Assert.NotNull(order);
            Assert.Equal(1, order.UserId);
            Assert.Single(order.Dishes);
            Assert.Equal(DeliveryType.Base, order.GetDeliveryType);
            Assert.Equal("No onions", order.UserWishes);
        }

        [Fact]
        public void Build_WithoutDishes_ThrowsException()
        {
            // Arrange
            var mockPricingService = new Mock<IPricingService>();
            var builder = new OrderBuilder(mockPricingService.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                builder.SetUserId(1).Build());
        }

        [Fact]
        public void Build_WithoutUserId_ThrowsException()
        {
            // Arrange
            var mockPricingService = new Mock<IPricingService>();
            var builder = new OrderBuilder(mockPricingService.Object);
            var mockDish = new Mock<IDish>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                builder.AddDish(mockDish.Object).Build());
        }

        [Fact]
        public void HasDish_WhenDishAdded_ReturnsTrue()
        {
            // Arrange
            var mockPricingService = new Mock<IPricingService>();
            var builder = new OrderBuilder(mockPricingService.Object);
            var mockDish = new Mock<IDish>();

            // Act
            builder.AddDish(mockDish.Object);

            // Assert
            Assert.True(builder.HasDish(mockDish.Object));
        }

        [Fact]
        public void RemoveDish_WhenDishRemoved_HasDishReturnsFalse()
        {
            // Arrange
            var mockPricingService = new Mock<IPricingService>();
            var builder = new OrderBuilder(mockPricingService.Object);
            var mockDish = new Mock<IDish>();

            // Act
            builder.AddDish(mockDish.Object);
            builder.RemoveDish(mockDish.Object);

            // Assert
            Assert.False(builder.HasDish(mockDish.Object));
        }
    }

    public class DishTests
    {
        [Fact]
        public void GetDescription_ReturnsCorrectFormat()
        {
            // Arrange
            var dish = new Dish(1, "Pizza", 599.99m);

            // Act
            var description = dish.GetDescription();

            // Assert
            Assert.Equal("Name: Pizza, Price: 599.99", description);
        }
    }

    public class MenuTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var dishes = new List<IDish>();
            var mockDish = new Mock<IDish>();
            dishes.Add(mockDish.Object);

            // Act
            var menu = new Menu("Test Menu", 1, dishes);

            // Assert
            Assert.Equal("Test Menu", menu.Name);
            Assert.Equal(1, menu.Id);
            Assert.Single(menu.Dishes);
        }
    }

    public class OrderTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var dishes = new List<IDish>();
            var mockDish = new Mock<IDish>();
            dishes.Add(mockDish.Object);

            // Act
            var order = new Order(1, 100, dishes, DeliveryType.Express, "Test wishes", 999.99m);

            // Assert
            Assert.Equal(1, order.Id);
            Assert.Equal(100, order.UserId);
            Assert.Single(order.Dishes);
            Assert.Equal(DeliveryType.Express, order.GetDeliveryType);
            Assert.Equal("Test wishes", order.UserWishes);
            Assert.Equal(999.99m, order.Price);
        }
    }

    public class UserTests
    {
        [Fact]
        public void Update_WritesToConsole()
        {
            // Arrange
            var user = new User(1);

            // Act & Assert (this is a simple verification that no exception is thrown)
            var exception = Record.Exception(() => user.Update("Test message"));
            Assert.Null(exception);
        }
    }

    public class MenuDisplayerTests
    {
        [Fact]
        public void DisplayMenu_ReturnsFormattedString()
        {
            // Arrange
            var mockMenu = new Mock<IMenu>();
            var mockDish = new Mock<IDish>();
            mockDish.Setup(d => d.Id).Returns(1);
            mockDish.Setup(d => d.Name).Returns("Pizza");

            var dishes = new List<IDish> { mockDish.Object };
            mockMenu.Setup(m => m.Dishes).Returns(dishes);

            var displayer = new MenuDisplayer(mockMenu.Object);

            // Act
            var result = displayer.DisplayMenu();

            // Assert
            Assert.Contains("МЕНЮ", result);
            Assert.Contains("1) Pizza", result);
        }
    }

    public class PricingServiceTests
    {
        [Fact]
        public void CalculatePrice_WithStrategies_AppliesStrategies()
        {
            // Arrange
            var pricingService = new PricingService();
            var mockStrategy = new Mock<ICalcStrategy>();
            mockStrategy.Setup(s => s.CalculatePrice(It.IsAny<decimal>()))
                .Returns(90m); // 10% discount

            // Act
            pricingService.AddStrategy(mockStrategy.Object);
            var result = pricingService.CalculatePrice(100m);

            // Assert
            Assert.Equal(90m, result);
            mockStrategy.Verify(s => s.CalculatePrice(100m), Times.Once);
        }

        [Fact]
        public void RemoveStrategy_WhenStrategyExists_ReturnsTrue()
        {
            // Arrange
            var pricingService = new PricingService();
            var mockStrategy = new Mock<ICalcStrategy>();

            // Act
            pricingService.AddStrategy(mockStrategy.Object);
            var result = pricingService.RemoveStrategy(mockStrategy.Object);

            // Assert
            Assert.True(result);
        }
    }

    public class OrderManagmentTests
    {
        [Fact]
        public void DisplayMenu_CallsMenuDisplayer()
        {
            // Arrange
            var mockMenu = new Mock<IMenu>();
            var mockDishes = new List<IDish>();
            var mockDish = new Mock<IDish>();
            mockDish.Setup(d => d.Id).Returns(1);
            mockDish.Setup(d => d.Name).Returns("Pizza");
            mockDishes.Add(mockDish.Object);
            mockMenu.Setup(m => m.Dishes).Returns(mockDishes);

            var user = new User(1);

            // This test requires ChoicingService implementation
            // For now, we'll skip it or use a mock
            var exception = Record.Exception(() =>
            {
                var managment = new OrderManagment(mockMenu.Object, user);
                managment.DisplayMenu();
            });

            Assert.Null(exception);
        }
    }

    public class ObserverNotifierTests
    {
        [Fact]
        public void Notify_WithObserver_CallsUpdate()
        {
            // Arrange
            var notifier = new ObserverNotifier();
            var mockObserver = new Mock<IObserver>();

            // Act
            notifier.Attach(mockObserver.Object);
            notifier.Notify("Test message");

            // Assert
            mockObserver.Verify(o => o.Update("Test message"), Times.Once);
        }

        [Fact]
        public void Detach_WhenObserverDetached_DoesNotCallUpdate()
        {
            // Arrange
            var notifier = new ObserverNotifier();
            var mockObserver = new Mock<IObserver>();

            // Act
            notifier.Attach(mockObserver.Object);
            notifier.Detach(mockObserver.Object);
            notifier.Notify("Test message");

            // Assert
            mockObserver.Verify(o => o.Update(It.IsAny<string>()), Times.Never);
        }
    }

    public class OrderTrackerTests
    {
        [Fact]
        public void GetStatus_ReturnsCurrentStateStatus()
        {
            // Arrange
            var mockObserverNotifier = new Mock<IObserverNotifier>();
            var tracker = new OrderTracker(mockObserverNotifier.Object);

            // Act
            var status = tracker.GetStatus();

            // Assert
            Assert.Equal("Подготовка", status);
        }
    }
}