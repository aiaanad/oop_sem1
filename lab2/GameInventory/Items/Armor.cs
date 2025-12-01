namespace GameInventory.Items;

using GameInventory.Interfaces;
using GameInventory.IItems;

public class Armor : Item, IArmor
{

    public int Damage { get; private set; }
    public Armor(string name, int weight, int value, int damage)
        : base(name, weight, value)
    {
        this.Damage = damage;
    }

    public override string GetDescription()
    {
        string begin = base.GetDescription();
        return $"{begin}\n      Урон: {Damage}";
    }
    // буст
    public int BoostLevel { get; private set; } = 0;
    public IBoostable Boost(int boostValue)
    {
        Value += boostValue;
        BoostLevel++;
        return this;
    }
}