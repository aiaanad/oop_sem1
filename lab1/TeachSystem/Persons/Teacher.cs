using TeachSystem.Interfaces;
namespace TeachSystem.Persons;

public class Teacher : Person, ITeacher
{
    public Teacher(string name, string surname, int age) : base(name, surname, age) { }
    public int WorkStage {  get; set; }
    public override string GetCourses()
    {
        return "Преподаватель ведет курсы: " + base.GetCourses();
    }
}