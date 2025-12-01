namespace GameInventory.Services;

using GameInventory.MixStrategies;
using GameInventory.Interfaces;
using GameInventory.Factories;


public class SetMixesService
{
    private readonly List<IMixStrategy> _availableMixes;

    // по умолчанию
    public SetMixesService(IPotionFactory potionFactory)
    {
        _availableMixes = new List<IMixStrategy>
        {
            new HealingManaStrategy(potionFactory),
            new SameEffectStrategy(potionFactory)
        };
    }

    public SetMixesService(List<IMixStrategy> strategies)
    {
        _availableMixes = new List<IMixStrategy>(strategies);
    }

    public List<IMixStrategy> GetMixes()
    {
        return _availableMixes;
    }

    public void AddMix(IMixStrategy strategy)
    {
        if (!_availableMixes.Contains(strategy))
        {
            _availableMixes.Add(strategy);
        }
    }

    public void RemoveMix(IMixStrategy strategy)
    {
        _availableMixes.Remove(strategy);
    }

    public void ClearMixes()
    {
        _availableMixes.Clear();
    }
   
}