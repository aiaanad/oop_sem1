namespace TeachSystem.Interfaces;

public interface ICourse
{
    string Name { get; }
    string Format { get; }
    string Description { get; }

    void AddTeacher(ITeacher teacher);
    void AddStudent(IStudent student);
    bool RemoveTeacher(ITeacher teacher);
    bool RemoveStudent(IStudent student);
    string GetStudents();
}