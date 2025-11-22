namespace TeachSystem.Courses;

public class OfflineCourse : Course
{
    public OfflineCourse(string name, string description="") : base(name, description) { }
    public override string Format { get => "־פכאים"; }
    public string Place { get; set; }
    public string Cabinet { get; set; }
}