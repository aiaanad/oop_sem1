using TeachSystem.Interfaces;
namespace TeachSystem.Persons;

public class Student : Person, IStudent
{
    public Student(string name, string surname, int age) : base(name, surname, age) { }
    public string School {  get; set; }
    public override string GetCourses()
    {
        return "Студент записан на курсы: " + base.GetCourses();
    }
}