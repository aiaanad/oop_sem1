namespace GameInventory.Services;

using GameInventory.Interfaces;

public class DisplayService
{
    private readonly IInventory _inventory;
    public DisplayService(IInventory inventory)
    {
        _inventory = inventory; 
    }
    public void DisplayInventory()
    {
        Console.WriteLine("\n—Œ—“ŒﬂÕ»≈ »Õ¬≈Õ“¿–ﬂ:\n");
        int i = 1;
        foreach (var item in _inventory.Items)
        {
            Console.WriteLine($"{i}) {item.GetDescription()}");
            i++;
        }
    }
}