namespace GameInventory.Items;

using GameInventory.Interfaces;
using GameInventory.IItems;


public class Weapon : Item, IWeapon
{
    public int Secure {  get; private set; }
    public Weapon(string name, int weight, int value, int secure)
        : base(name, weight, value)
    {
        Secure = secure;
    }

    public string GetDescription()
    {
        string begin = base.GetDescription();
        return $"{begin}\n{(IsEquipped ? "  Экипирован. " : "   ")}     Защита брони: {Secure}";
    }

    // буст
    public int BoostLevel { get; private set; } = 0;
    public IBoostable Boost(int boostedValue)
    {
        Value += boostedValue;
        BoostLevel++;
        return this;
    }
    // экипировка
    public bool IsEquipped { get; private set; } = false;
    public void Equip(int equipValue)
    {
        Value += equipValue;
        IsEquipped = true;
    }
    public void UnEquip(int equipValue)
    {    
        Value -= equipValue;
        IsEquipped = false;  
    }
}