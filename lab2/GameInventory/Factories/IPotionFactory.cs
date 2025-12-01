namespace GameInventory.Factories;

using GameInventory.IItems;

public interface IPotionFactory
{
    IPotion CreatePotion(string name, int weight, int value);
}