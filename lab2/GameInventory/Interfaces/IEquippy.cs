namespace GameInventory.Interfaces;

public interface IEquippy : IItem
{
    bool IsEquipped { get; }
    void Equip(int equipValue);
    void UnEquip(int equipValue);
}