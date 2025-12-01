namespace GameInventory.IItems;

using GameInventory.Interfaces;

public interface IArmor : IBoostable, IUsable
{
    int Damage { get; }
}