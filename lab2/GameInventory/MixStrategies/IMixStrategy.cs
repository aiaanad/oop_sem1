namespace GameInventory.MixStrategies;

using GameInventory.IItems;

public interface IMixStrategy
{
    bool CanMix(IPotion first, IPotion second);
    IPotion Mix(IPotion first, IPotion second);
}