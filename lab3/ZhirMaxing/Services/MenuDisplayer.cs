namespace ZhirMaxing.Services;

using ZhirMaxing.Interfaces;

public class MenuDisplayer: IMenuDisplayer
{
    private IMenu _menu;
    public MenuDisplayer(IMenu menu) { _menu = menu; }

    public string DisplayMenu()
    {
        string data = "\nÌÅÍŞ:\n\n";
        foreach(var dish in _menu.Dishes)
        {
            data += $"{dish.Id}) {dish.Name}\n";
        }
        return data;
    }
}