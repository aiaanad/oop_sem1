namespace GameInventory.Items;

using GameInventory.Interfaces;
using GameInventory.IItems;


public class Potion : Item, IPotion
{
    public string Effect { get; }

    public Potion(string name, int weight, int value, string effect)
        : base(name, weight, value)
    {
        this.Effect = effect;
    }

    public string GetDescription()
    {
        string begin = base.GetDescription();
        return $"{begin}\n      Если выпить, то получаешь бафф в виде: {Effect}";
    }
}