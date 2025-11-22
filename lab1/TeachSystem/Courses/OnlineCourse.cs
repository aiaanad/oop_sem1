namespace TeachSystem.Courses;

public class OnlineCourse : Course
{
    public OnlineCourse(string name, string description = "") : base(name, description) { }
    public override string Format { get => "Онлайн"; }
    public string Platform { get; set; }
    public string Permalink { get; set; }
}