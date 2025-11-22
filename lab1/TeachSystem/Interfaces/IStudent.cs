namespace TeachSystem.Interfaces;

public interface IStudent : IPerson
{
    string School { get; }
    void AddCourse(ICourse course);
    bool RemoveCourse(ICourse course);
}