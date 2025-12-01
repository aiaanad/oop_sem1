using Xunit;
using GameInventory.MixStrategies;
using GameInventory.Items;

namespace GameInventory.Tests;

public class StrategyTests
{
	[Fact]
	public void SameEffectStrategy_CanMix_Should_Return_True_For_Same_Effects()
	{
		var strategy = new SameEffectStrategy();
		var potion1 = new Potion("Health", 1, 50, "heal");
		var potion2 = new Potion("Super Health", 2, 80, "heal");

		Assert.True(strategy.CanMix(potion1, potion2));
	}

	[Fact]
	public void SameEffectStrategy_Mix_Should_Create_Concentrated_Potion()
	{
		var strategy = new SameEffectStrategy();
		var potion1 = new Potion("Mana", 1, 30, "mana");
		var potion2 = new Potion("Mana", 2, 60, "mana");

		var result = strategy.Mix(potion1, potion2);

		Assert.Contains("Концентрированное", result.Name);
		Assert.Equal(3, result.Weight);
		Assert.Equal(90, result.Value);
		Assert.Equal("mana", result.Effect);
	}

	[Fact]
	public void HealingManaStrategy_CanMix_Should_Return_True_For_Heal_And_Mana()
	{
		var strategy = new HealingManaStrategy();
		var heal = new Potion("Health", 1, 50, "heal");
		var mana = new Potion("Mana", 1, 40, "mana");

		Assert.True(strategy.CanMix(heal, mana));
	}
}