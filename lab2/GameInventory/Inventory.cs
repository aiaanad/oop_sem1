using GameInventory.Interfaces;
using GameInventory.Services;


public class Inventory: IInventory
{   
    private List<IItem> items = new List<IItem>();
    public IReadOnlyList<IItem> Items { get => items; }

    public bool HasItem(IItem item)
    {
        return items.Contains(item); 
    }

    public void AddItem(IItem item)
    {
        if (!HasItem(item))
            items.Add(item); 
    }

    public bool RemoveItem(IItem item)
    {
        if (!HasItem(item)) 
            return false;
        return items.Remove(item);
    }

}
