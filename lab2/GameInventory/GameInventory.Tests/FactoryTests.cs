using Xunit;
using GameInventory.Factories;
using GameInventory.IItems;

namespace GameInventory.Tests;

public class FactoryTests
{
    [Fact]
    public void HealPotionFactory_Should_Create_Heal_Potion()
    {
        var factory = new HealPotionFactory();
        var potion = factory.CreatePotion("Health", 1, 50);

        Assert.Equal("heal", potion.Effect);
    }

    [Fact]
    public void ManaPotionFactory_Should_Create_Mana_Potion()
    {
        var factory = new ManaPotionFactory();
        var potion = factory.CreatePotion("Mana", 1, 40);

        Assert.Equal("mana", potion.Effect);
    }

    [Theory]
    [InlineData("heal")]
    [InlineData("mana")]
    [InlineData("restore_all")]
    public void PotionFactory_Should_Use_Passed_Effect(string effect)
    {
        var factory = new PotionFactory(effect);
        var potion = factory.CreatePotion("Potion", 1, 10);

        Assert.Equal(effect, potion.Effect);
    }
}
