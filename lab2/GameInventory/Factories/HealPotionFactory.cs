namespace GameInventory.Factories;

using GameInventory.IItems;
using GameInventory.Items;

public class HealPotionFactory : IPotionFactory
{
	public IPotion CreatePotion(string name, int weight, int value)
		=> new Potion(name, weight, value, "heal");
}