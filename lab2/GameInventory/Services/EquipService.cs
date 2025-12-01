namespace GameInventory.Services;

using GameInventory.Interfaces;
using GameInventory.Results;

public class EquipService
{
    private readonly IInventory _inventory;

    public EquipService(IInventory inventory)
    {
        _inventory = inventory; 
    }

    public ServiceResult<object> EquipItem(IEquippy item, int equipValue)
    {
        if (item == null) {
            return ServiceResult<object>.Failed("Вещь должна существовать");
        }
        if (equipValue < 0) {
            return ServiceResult<object>.Failed("Значение экипировки не может быть отрицательным");
        }
        if (!_inventory.HasItem(item)) {
            return ServiceResult<object>.Failed("Вещи нет в инвентаре");
        }
        
        try
        {
            item.Equip(equipValue);
            return ServiceResult<object>.Success("Вещь экипирована");
        }
        catch 
        { 
            return ServiceResult<object>.Failed("Ошибка при экипировке");
        }
            
        
    }
    public ServiceResult<object> UnEquipItem(IEquippy item, int equipValue)
    {
        if (equipValue < 0) {
            return ServiceResult<object>.Failed("Значение экипировки не может быть отрицательным");
        }
        if (!_inventory.HasItem(item)) {
            return ServiceResult<object>.Failed("Вещи нет в инвентаре");
        }
        try
        {
            item.UnEquip(equipValue);
            return ServiceResult<object>.Success("Экипировка снята");
        }
        catch { return ServiceResult<object>.Failed("Ошибка при снятии"); }
    }
}