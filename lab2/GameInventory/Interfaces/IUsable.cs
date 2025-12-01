namespace GameInventory.Interfaces;

public interface IUsable : IItem
{
    bool isUsed { get; }
    void Use(int useResource);
    void UnUse();
}