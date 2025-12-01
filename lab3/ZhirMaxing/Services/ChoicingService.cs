namespace ZhirMaxing.Services;

using ZhirMaxing.Interfaces;

public class ChoicingService: IChoicingService
{
    private IMenu _menu;

    public ChoicingService(IMenu menu)
    {
        _menu = menu;
    }
    public bool IsCorrect(int id)
    {
        return _menu.Dishes.Any(x => x.Id == id);
    }
    public IDish GetDishWithId(int id)
    {
        var dish = _menu.Dishes.FirstOrDefault(x => x.Id == id);
        return dish;
    }
}