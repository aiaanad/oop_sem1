namespace TeachSystem.Interfaces;

public interface IPerson
{
    string Name { get; }
    string Surname { get; }
    string FullName { get; }
    int Age { get; }
}