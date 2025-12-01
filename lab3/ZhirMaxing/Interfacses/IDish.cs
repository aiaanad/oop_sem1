namespace ZhirMaxing.Interfaces;

public interface IDish
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    string GetDescription();
}