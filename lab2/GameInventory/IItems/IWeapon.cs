namespace GameInventory.IItems;

using GameInventory.Interfaces;

public interface IWeapon : IBoostable, IUsable, IEquippy
{
    int Secure { get; }
}