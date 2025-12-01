using Xunit;
using GameInventory.Items;

namespace GameInventory.Tests;

public class InventoryTests
{
    [Fact]
    public void AddItem_Should_Add_Item_Only_Once()
    {
        var inventory = new Inventory();
        var potion = new Potion("Test", 1, 10, "test");

        inventory.AddItem(potion);
        inventory.AddItem(potion); // Дублирование

        Assert.Single(inventory.Items);
    }

    [Fact]
    public void RemoveItem_Should_Return_False_For_Non_Existent_Item()
    {
        var inventory = new Inventory();
        var potion = new Potion("Test", 1, 10, "test");

        Assert.False(inventory.RemoveItem(potion));
    }
}