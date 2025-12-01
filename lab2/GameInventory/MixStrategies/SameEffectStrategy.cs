namespace GameInventory.MixStrategies;

using GameInventory.IItems;
using GameInventory.Factories;

public class SameEffectStrategy : IMixStrategy
{
    private IPotionFactory _potionFactory;
	public SameEffectStrategy(IPotionFactory potionFactory)
	{
		_potionFactory = potionFactory;
	}


    public bool CanMix(IPotion first, IPotion second)
	{
		return first.Effect == second.Effect;
	}

	public IPotion Mix(IPotion first, IPotion second)
	{
		return _potionFactory.CreatePotion($"Концентрированное {first.Name}",
						 first.Weight + second.Weight,
						 first.Value + second.Value);
	}
}
