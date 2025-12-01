namespace ZhirMaxing.Interfaces;

public interface IMenu
{
    int Id { get; }
    string Name { get; }
    List<IDish> Dishes { get; }
}
