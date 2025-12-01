namespace GameInventory.IItems;

using GameInventory.Interfaces;

public interface IPotion: IUsable
{
    string Effect { get; }
}