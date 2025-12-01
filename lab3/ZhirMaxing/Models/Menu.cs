namespace ZhirMaxing.Models;

using ZhirMaxing.Interfaces;

public class Menu: IMenu
{
    private List<IDish> _dishes = new List<IDish>();
    private string _name;
    private int _id;

    public Menu(string name, int id, List<IDish> dishes)
    {
        _name = name;
        _id = id;
        _dishes = dishes;
    }

    public int Id => _id;
    public string Name => _name;
    public List<IDish> Dishes => _dishes;

}