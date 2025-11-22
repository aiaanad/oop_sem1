using TeachSystem.Interfaces;
using TeachSystem.Persons;
using TeachSystem.Courses;

namespace TeachSystem;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("TEACH SYSTEM - СИСТЕМА УПРАВЛЕНИЯ КУРСАМИ");
        Console.WriteLine(new string('=', 50));

        DemonstrateCourseManagement();
        DemonstratePersonManagement();
        DemonstrateCourseTypes();
        DemonstrateInformationRetrieval();

        Console.WriteLine("\nДемонстрация возможностей системы завершена.");
    }

    static void DemonstrateCourseManagement()
    {
        Console.WriteLine("\n1. УПРАВЛЕНИЕ КУРСАМИ - ДОБАВЛЕНИЕ И УДАЛЕНИЕ");
        Console.WriteLine(new string('-', 40));

        var onlineCourse = new OnlineCourse("C# Programming", "Основы программирования на C#");
        var offlineCourse = new OfflineCourse("Algorithms", "Алгоритмы и структуры данных");

        onlineCourse.Platform = "Zoom";
        onlineCourse.Permalink = "https://zoom.us/j/123456";

        offlineCourse.Place = "Главный корпус";
        offlineCourse.Cabinet = "Аудитория 301";

        Console.WriteLine("Созданы курсы:");
        Console.WriteLine($"- {onlineCourse.Name} ({onlineCourse.Format})");
        Console.WriteLine($"- {offlineCourse.Name} ({offlineCourse.Format})");

        var tempCourse = new OnlineCourse("Temporary Course", "Временный курс");
        Console.WriteLine($"\nСоздан временный курс: {tempCourse.Name}");
        Console.WriteLine($"Удален временный курс: {tempCourse.Name}");
    }

    static void DemonstratePersonManagement()
    {
        Console.WriteLine("\n2. УПРАВЛЕНИЕ ПЕРСОНАМИ - ПРЕПОДАВАТЕЛИ И СТУДЕНТЫ");
        Console.WriteLine(new string('-', 40));

        var teacher1 = new Teacher("Иван", "Петров", 35);
        var teacher2 = new Teacher("Мария", "Сидорова", 42);

        teacher1.WorkStage = 10;
        teacher2.WorkStage = 15;

        var student1 = new Student("Алексей", "Иванов", 20);
        var student2 = new Student("Екатерина", "Смирнова", 21);
        var student3 = new Student("Дмитрий", "Козлов", 22);

        student1.School = "Школа №1";
        student2.School = "Школа №2";
        student3.School = "Лицей №3";

        var course1 = new OnlineCourse("C# Programming", "Основы C#");
        var course2 = new OfflineCourse("Algorithms", "Алгоритмы");

        Console.WriteLine("Назначение преподавателей на курсы:");
        course1.AddTeacher(teacher1);
        course2.AddTeacher(teacher2);
        course1.AddTeacher(teacher2);

        Console.WriteLine("\nЗапись студентов на курсы:");
        course1.AddStudent(student1);
        course1.AddStudent(student2);
        course2.AddStudent(student3);
        course2.AddStudent(student1);

        teacher1.AddCourse(course1);
        teacher2.AddCourse(course1);
        teacher2.AddCourse(course2);

        student1.AddCourse(course1);
        student1.AddCourse(course2);
        student2.AddCourse(course1);
        student3.AddCourse(course2);
    }

    static void DemonstrateCourseTypes()
    {
        Console.WriteLine("\n3. ТИПЫ КУРСОВ - ОНЛАЙН И ОФЛАЙН");
        Console.WriteLine(new string('-', 40));

        var onlineCourse = new OnlineCourse("Web Development", "Разработка веб-приложений")
        {
            Platform = "Microsoft Teams",
            Permalink = "https://teams.live/web-dev"
        };

        var offlineCourse = new OfflineCourse("Database Design", "Проектирование баз данных")
        {
            Place = "Технический корпус",
            Cabinet = "Лаборатория 205"
        };

        Console.WriteLine("Онлайн курс:");
        Console.WriteLine($"- Название: {onlineCourse.Name}");
        Console.WriteLine($"- Формат: {onlineCourse.Format}");
        Console.WriteLine($"- Платформа: {onlineCourse.Platform}");
        Console.WriteLine($"- Ссылка: {onlineCourse.Permalink}");

        Console.WriteLine("\nОфлайн курс:");
        Console.WriteLine($"- Название: {offlineCourse.Name}");
        Console.WriteLine($"- Формат: {offlineCourse.Format}");
        Console.WriteLine($"- Место: {offlineCourse.Place}");
        Console.WriteLine($"- Аудитория: {offlineCourse.Cabinet}");
    }

    static void DemonstrateInformationRetrieval()
    {
        Console.WriteLine("\n4. ПОЛУЧЕНИЕ ИНФОРМАЦИИ О СИСТЕМЕ");
        Console.WriteLine(new string('-', 40));

        var teacher1 = new Teacher("Иван", "Петров", 35) { WorkStage = 10 };
        var teacher2 = new Teacher("Мария", "Сидорова", 42) { WorkStage = 15 };

        var student1 = new Student("Алексей", "Иванов", 20) { School = "Школа №1" };
        var student2 = new Student("Екатерина", "Смирнова", 21) { School = "Школа №2" };
        var student3 = new Student("Дмитрий", "Козлов", 22) { School = "Лицей №3" };

        var course1 = new OnlineCourse("C# Programming", "Основы C#");
        var course2 = new OfflineCourse("Algorithms", "Алгоритмы");
        var course3 = new OnlineCourse("Web Development", "Веб-разработка");

        course1.AddTeacher(teacher1);
        course2.AddTeacher(teacher2);
        course3.AddTeacher(teacher1);
        course3.AddTeacher(teacher2);

        course1.AddStudent(student1);
        course1.AddStudent(student2);
        course2.AddStudent(student3);
        course3.AddStudent(student1);
        course3.AddStudent(student2);
        course3.AddStudent(student3);

        teacher1.AddCourse(course1);
        teacher1.AddCourse(course3);
        teacher2.AddCourse(course2);
        teacher2.AddCourse(course3);

        student1.AddCourse(course1);
        student1.AddCourse(course3);
        student2.AddCourse(course1);
        student2.AddCourse(course3);
        student3.AddCourse(course2);
        student3.AddCourse(course3);

        Console.WriteLine("Курсы преподавателя Ивана Петрова:");
        Console.WriteLine($"- {teacher1.GetCourses()}");

        Console.WriteLine("\nКурсы преподавателя Марии Сидоровой:");
        Console.WriteLine($"- {teacher2.GetCourses()}");

        Console.WriteLine("\nСтуденты на курсах:");
        Console.WriteLine($"Курс 'C# Programming': {course1.GetStudents()}");
        Console.WriteLine($"Курс 'Algorithms': {course2.GetStudents()}");
        Console.WriteLine($"Курс 'Web Development': {course3.GetStudents()}");

        Console.WriteLine("\nКурсы студентов:");
        Console.WriteLine($"Студент Алексей Иванов: {student1.GetCourses()}");
        Console.WriteLine($"Студент Екатерина Смирнова: {student2.GetCourses()}");
        Console.WriteLine($"Студент Дмитрий Козлов: {student3.GetCourses()}");

        Console.WriteLine("\n5. ДЕМОНСТРАЦИЯ УДАЛЕНИЯ");
        Console.WriteLine(new string('-', 40));

        Console.WriteLine("До удаления:");
        Console.WriteLine($"Студенты на C# Programming: {course1.GetStudents()}");

        course1.RemoveStudent(student1);
        Console.WriteLine($"После удаления Алексея Иванова: {course1.GetStudents()}");

        course3.RemoveTeacher(teacher1);
        Console.WriteLine($"Курсы Ивана Петрова после удаления: {teacher1.GetCourses()}");
    }
}

public class CourseManagementSystem
{
    private List<ICourse> _courses = new List<ICourse>();
    private List<ITeacher> _teachers = new List<ITeacher>();
    private List<IStudent> _students = new List<IStudent>();

    public void AddCourse(ICourse course) => _courses.Add(course);
    public void RemoveCourse(ICourse course) => _courses.Remove(course);
    public void AddTeacher(ITeacher teacher) => _teachers.Add(teacher);
    public void AddStudent(IStudent student) => _students.Add(student);

    public void DisplayAllCourses()
    {
        Console.WriteLine("\nВсе курсы в системе:");
        foreach (var course in _courses)
        {
            Console.WriteLine($"- {course.Name} ({course.Format})");
        }
    }
}
