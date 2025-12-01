namespace GameInventory.Interfaces;

public interface IBoostable : IItem
{
    int BoostLevel {  get; }
    IBoostable Boost(int boostValue);
}