namespace GameInventory.Services;

using GameInventory.Interfaces;
using GameInventory.Results;

public class BoostService
{
    private readonly IInventory _inventory;

    public BoostService(IInventory inventory)
    {
        _inventory = inventory; 
    }

    public ServiceResult<object> BoostItem(IBoostable item, int boostValue)
    {
        if (item == null) {
            return ServiceResult<object>.Failed("Вещь для буста должна существовать");
        }
        if (boostValue < 0) {
            return ServiceResult<object>.Failed("Значение буста должно быть положительным");
        }
        if (!_inventory.HasItem(item)) {
            return ServiceResult<object>.Failed("Вещь не в инвентаре");
        }
        try
        {
            var boostedItem = item.Boost(boostValue);
            if (_inventory.RemoveItem(item))
            {
                _inventory.AddItem(boostedItem);
                return ServiceResult<object>.Success("Успешно улучшен предмет");
            }
            return ServiceResult<object>.Success("Нельзя удалить предмет");
        }
        catch
        {
            return ServiceResult<object>.Failed("Ошибка во время улучения");
        }
    }
}
