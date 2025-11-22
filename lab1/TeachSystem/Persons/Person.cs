namespace TeachSystem.Persons;

using TeachSystem.Interfaces;

public abstract class Person : IPerson
{
    private string _name;
    private string _surname;
    private int _age;
    protected List<ICourse> _courses = new List<ICourse>();

    public Person(string name, string surname, int age)
    {
        _name = name;
        _surname = surname;
        _age = age;
    }
    public string Name { get => _name; }
    public string Surname { get => _surname; }
    public string FullName { get => _name + " " + _surname; }
    public int Age { get => _age; }

    public virtual void AddCourse(ICourse course)
    {
        if (course == null) throw new ArgumentNullException(nameof(course));
        if (_courses.Contains(course)) throw new InvalidOperationException();

        _courses.Add(course);
    }
    public virtual bool RemoveCourse(ICourse course)
    {
        if (course == null) return false;
        if (!_courses.Contains(course)) return false;

        return _courses.Remove(course);
    }

    public virtual string GetCourses()
    {
        if (!_courses.Any() || _courses == null) return "≈ще нет курсов";
        return string.Join(", ", _courses.Select(c => c.Name));
    }

}