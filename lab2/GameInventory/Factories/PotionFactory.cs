namespace GameInventory.Factories;

using GameInventory.IItems;
using GameInventory.Items;

public class PotionFactory : IPotionFactory
{
    private readonly string _effect;
    public PotionFactory(string effect = "heal")
    {
        _effect = effect;
    }
    public IPotion CreatePotion(string name, int weight, int value)
        => new Potion(name, weight, value, _effect);
}