namespace TeachSystem.Interfaces;

public interface ITeacher : IPerson
{
    int WorkStage { get; set; }
    void AddCourse(ICourse course);
    bool RemoveCourse(ICourse course);
}