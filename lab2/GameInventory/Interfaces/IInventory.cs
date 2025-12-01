namespace GameInventory.Interfaces;


public interface IInventory 
{
    public IReadOnlyList<IItem> Items { get; }
    public bool HasItem(IItem item);
    public void AddItem(IItem item);
    public bool RemoveItem(IItem item);
}
