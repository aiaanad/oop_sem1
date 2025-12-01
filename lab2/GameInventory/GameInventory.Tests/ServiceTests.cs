using Xunit;
using Moq;
using GameInventory.Services;
using GameInventory.Interfaces;
using GameInventory.Items;
using GameInventory.Results;

namespace GameInventory.Tests;

public class ServiceTests
{
	[Fact]
	public void BoostService_Should_Boost_Item_In_Inventory()
	{
		// Arrange
		var mockInventory = new Mock<IInventory>();
		var armor = new Armor("Shield", 10, 100, 5);

		mockInventory.Setup(i => i.HasItem(armor)).Returns(true);
		mockInventory.Setup(i => i.RemoveItem(armor)).Returns(true);

		var service = new BoostService(mockInventory.Object);

		// Act
		var result = service.BoostItem(armor, 50);

		// Assert
		Assert.True(result.IsSuccess);
		mockInventory.Verify(i => i.AddItem(It.IsAny<IBoostable>()), Times.Once);
	}

	[Fact]
	public void UseService_Should_Fail_When_Item_Not_In_Inventory()
	{
		// Arrange
		var mockInventory = new Mock<IInventory>();
		var potion = new Potion("Health", 1, 50, "heal");

		mockInventory.Setup(i => i.HasItem(potion)).Returns(false);
		var service = new UseService(mockInventory.Object);

		// Act
		var result = service.UseItem(potion, 10);

		// Assert
		Assert.False(result.IsSuccess);
		Assert.Contains("нет в инвентаре", result.Message);
	}
}