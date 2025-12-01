namespace GameInventory.Items;

using GameInventory.Interfaces;

public abstract class Item : IItem, IUsable
{
    public string Name { get; protected set; } = "";
    public int Weight { get; protected set; } = 0;
    public int Value { get; protected set; } = 0;

    protected Item(string name, int weight, int value)
    {
        Name = name;
        Weight = weight;
        Value = value;
    } 

    public virtual string GetDescription()
    {
        return $"{Name}. Сейчас {(!isUsed ? "не " : "")}используется. (Вес: {Weight}, Ценность: {Value})";
    }

    public virtual bool isUsed { get; private set; } = false;
    public virtual void Use(int useResource)
    {
        if (Value >= useResource)
        {
            Value -= useResource;
            isUsed = true;
        }
    }
    public virtual void UnUse()
    {
        isUsed = false;
    }

}
