namespace GameInventory.MixStrategies;

using GameInventory.IItems;
using GameInventory.Factories;

public class HealingManaStrategy : IMixStrategy
{
    private IPotionFactory _potionFactory;
    public HealingManaStrategy(IPotionFactory potionFactory)
    {
        _potionFactory = potionFactory;
    }

    public bool CanMix(IPotion first, IPotion second)
    {
        var effects = new[] { first.Effect, second.Effect };
        return effects.Contains("heal") && effects.Contains("mana");
    }

    public IPotion Mix(IPotion first, IPotion second)
    {
        return _potionFactory.CreatePotion("Эликсир Всего Сущего",
                         first.Weight + second.Weight,
                         first.Value + second.Value);
    }
}
