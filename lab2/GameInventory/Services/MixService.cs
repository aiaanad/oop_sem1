namespace GameInventory.Services;

using GameInventory.Interfaces;
using GameInventory.IItems;
using GameInventory.MixStrategies;
using GameInventory.Factories;
using GameInventory.Results;

public class MixService
{
    private readonly IInventory _inventory;
    private List<IMixStrategy> _mixes;
    private IPotionFactory _potionFactory;

    public MixService(IInventory inventory, List<IMixStrategy> mixes, IPotionFactory potionFactory)
    {
        _inventory = inventory;
        _mixes = mixes;
        _potionFactory = potionFactory;
    }
    
    public bool CanMix(IPotion potion1, IPotion potion2)
    {
        return _mixes.Any(s => s.CanMix(potion1, potion2));
    }
    public ServiceResult<IPotion> PotionMix (IPotion potion1, IPotion potion2)
    {
        if (CanMix(potion1, potion2)) {
            var strategy = _mixes.FirstOrDefault(s => s.CanMix(potion1, potion2));
            if (strategy == null) {
                return ServiceResult<IPotion>.Failed("Не существует такого сочетания");
            }
            
            try
            {
                if (_inventory.RemoveItem(potion1) && _inventory.RemoveItem(potion2)) {
                    var potionsMix = strategy.Mix(potion1, potion2);
                    _inventory.AddItem(potionsMix);
                    return ServiceResult<IPotion>.Success(potionsMix, "Зелья успешно смешаны");
                }
                return ServiceResult<IPotion>.Failed("Возникли проблемы во время удаления");
            }
            catch 
            {
                return ServiceResult<IPotion>.Failed("Ошибка во время смешивания");
            }
        }
        
        return ServiceResult<IPotion>.Failed("Не существует такого сочетания");        
    }
}