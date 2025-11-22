namespace TeachSystem.Courses;

using TeachSystem.Interfaces;
using System.Collections.Generic;

public abstract class Course : ICourse
{
    private string _name;
    private string? _description;

    public Course(string name, string description="")
    {
        _name = name;
        _description = description;
    }

    protected List<IStudent> _students = new List<IStudent>();
    protected List<ITeacher> _teachers = new List<ITeacher>();

    public string Name { get =>  _name; set => _name = value; }
    public string Description { get => _description; set => _description = value; }
    public virtual string Format { get => "Base"; }

   

    public virtual void AddStudent(IStudent student)
    {
        if (student == null) throw new ArgumentNullException(nameof(student), "Студент не может быть null");
        if (_students.Contains(student)) throw new InvalidOperationException($"Студент {student.Name} уже записан на этот курс");
        
        _students.Add(student);
        Console.WriteLine($"Студент {student.Name} успешно записан на {this.Name}");
    }
    public virtual bool RemoveStudent(IStudent student)
    {
        if (student == null) return false;
        if (!_students.Contains(student)) return false;

        Console.WriteLine($"Студент {student.Name} успешно отписался от {this.Name}");
        return _students.Remove(student);
    }

    public virtual void AddTeacher(ITeacher teacher)
    {
        if (teacher == null) throw new ArgumentNullException(nameof(teacher), "Учитель не может быть null");
        if (_teachers.Contains(teacher)) throw new InvalidOperationException($"Учитель {teacher.Name} уже ведёт этот курс");

        _teachers.Add(teacher);
        Console.WriteLine($"Учитель {teacher.Name}  теперь ведёт  {this.Name}");
    }
    public virtual bool RemoveTeacher(ITeacher teacher)
    {
        if (teacher == null) return false;
        if (!_teachers.Contains(teacher)) return false;

        Console.WriteLine($"Учитель {teacher.Name} теперь не ведёт {this.Name}");
        return _teachers.Remove(teacher);
    }

    public virtual string GetStudents()
    {
        if (!_students.Any() || _students == null) return "Никто ещё не записан на курс";
            
        return "На курс записаны: " + string.Join(", ", _students.Select(s => s.Name));

    }

}