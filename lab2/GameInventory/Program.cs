using GameInventory.Interfaces;
using GameInventory.Items;
using GameInventory.Services;
using GameInventory.Factories;
using GameInventory.MixStrategies;

public class Program
{
    public static void Main()
    {
        var inventory = new Inventory();
        

        var potionFactory = new PotionFactory("крутой");
        var healpotionFactory = new HealPotionFactory();
        var manapotionFactory = new ManaPotionFactory();
        
        

        var potion1 = potionFactory.CreatePotion("зелье", 12, 12);
        var potion2 = manapotionFactory.CreatePotion("зелье вечной молодости",1234, 123);
        var potion3 = healpotionFactory.CreatePotion("бабл ти", 100, 1000);

        var armor = new Armor("щит капитана америки", 10, 10, 5);
        var weapon = new Weapon("тор тора", 10, 10, 3);

        
        inventory.AddItem(potion1);
        inventory.AddItem(potion2);
        inventory.AddItem(potion3);
        inventory.AddItem(armor);
        inventory.AddItem(weapon);

        var displayService = new DisplayService(inventory);
        displayService.DisplayInventory();


        var mixList = new SetMixesService(potionFactory);
        var mixService = new MixService(inventory, mixList.GetMixes(), potionFactory);
        Console.WriteLine("\nСообщение про смешивание:\n");
        Console.WriteLine(mixService.PotionMix(potion1, potion2));

        var useService = new UseService(inventory);
        Console.WriteLine("\nСообщение про использование:\n");
        Console.WriteLine(useService.UseItem(armor, 1));

        displayService.DisplayInventory();

       
     
    }
}