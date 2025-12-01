namespace GameInventory.Services;

using GameInventory.Interfaces;
using GameInventory.Results;

public class UseService
{
    private readonly IInventory _inventory;

    public UseService(IInventory inventory)
    {
        _inventory = inventory;
    }

    public ServiceResult<object> UseItem(IUsable item, int useResource)
    {
        try
        {
            if (!_inventory.HasItem(item))
            {
                
                return ServiceResult<object>.Failed("Вещи нет в инвентаре");
            }
            if (item.isUsed)
            {
                return ServiceResult<object>.Failed("Вещь уже используется");
                
            }
            item.Use(useResource);
            return ServiceResult<object>.Success("Предмет использован");
        }
        catch { return ServiceResult<object>.Failed("Предмет нельзя использвать"); }
    }
    public ServiceResult<object> UnUseItem(IUsable item)
    {
        try
        {
            if (!_inventory.HasItem(item))
            {
                return ServiceResult<object>.Failed("Вещи нет в инвентаре");
            }
            if (!item.isUsed)
            {
                return ServiceResult<object>.Failed("Вещь уже не используется");
            }
            item.UnUse();
            return ServiceResult<object>.Success("Вещь теперь не используется");
        }
        catch { return ServiceResult<object>.Failed("Предмет нельзя использовать"); }
    }
}