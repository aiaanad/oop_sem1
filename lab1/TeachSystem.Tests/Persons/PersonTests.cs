using TeachSystem.Persons;
using TeachSystem.Courses;
using TeachSystem.Interfaces;

namespace TeachSystem.Tests.Persons;

public class PersonTests
{
    [Fact]
    public void Person_Constructor_SetsPropertiesCorrectly()
    {
        // Arrange & Act
        var person = new TestPerson("John", "Doe", 25);

        // Assert
        Assert.Equal("John", person.Name);
        Assert.Equal("Doe", person.Surname);
        Assert.Equal("John Doe", person.FullName);
        Assert.Equal(25, person.Age);
    }

    [Fact]
    public void AddCourse_ValidCourse_AddsCourseSuccessfully()
    {
        // Arrange
        var person = new TestPerson("John", "Doe", 25);
        var course = new OnlineCourse("C# Basics", "Introduction to C#");

        // Act
        person.AddCourse(course);

        // Assert
        Assert.Contains(course, person.GetCoursesInternal());
    }

    [Fact]
    public void AddCourse_NullCourse_ThrowsArgumentNullException()
    {
        // Arrange
        var person = new TestPerson("John", "Doe", 25);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => person.AddCourse(null));
    }

    [Fact]
    public void AddCourse_DuplicateCourse_ThrowsInvalidOperationException()
    {
        // Arrange
        var person = new TestPerson("John", "Doe", 25);
        var course = new OnlineCourse("C# Basics", "Introduction to C#");
        person.AddCourse(course);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => person.AddCourse(course));
    }

    [Fact]
    public void RemoveCourse_ExistingCourse_ReturnsTrueAndRemovesCourse()
    {
        // Arrange
        var person = new TestPerson("John", "Doe", 25);
        var course = new OnlineCourse("C# Basics", "Introduction to C#");
        person.AddCourse(course);

        // Act
        var result = person.RemoveCourse(course);

        // Assert
        Assert.True(result);
        Assert.DoesNotContain(course, person.GetCoursesInternal());
    }

    [Fact]
    public void RemoveCourse_NonExistingCourse_ReturnsFalse()
    {
        // Arrange
        var person = new TestPerson("John", "Doe", 25);
        var course = new OnlineCourse("C# Basics", "Introduction to C#");

        // Act
        var result = person.RemoveCourse(course);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void RemoveCourse_NullCourse_ReturnsFalse()
    {
        // Arrange
        var person = new TestPerson("John", "Doe", 25);

        // Act
        var result = person.RemoveCourse(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetCourses_NoCourses_ReturnsNoCoursesMessage()
    {
        // Arrange
        var person = new TestPerson("John", "Doe", 25);

        // Act
        var result = person.GetCourses();

        // Assert
        Assert.Equal("Еще нет курсов", result);
    }

    [Fact]
    public void GetCourses_WithCourses_ReturnsCoursesList()
    {
        // Arrange
        var person = new TestPerson("John", "Doe", 25);
        var course1 = new OnlineCourse("C# Basics", "Introduction to C#");
        var course2 = new OfflineCourse("Algorithms", "Basic algorithms");
        person.AddCourse(course1);
        person.AddCourse(course2);

        // Act
        var result = person.GetCourses();

        // Assert
        Assert.Contains("C# Basics", result);
        Assert.Contains("Algorithms", result);
    }

    // Test class to access protected members
    private class TestPerson : Person
    {
        public TestPerson(string name, string surname, int age) : base(name, surname, age) { }

        public List<ICourse> GetCoursesInternal() => _courses;
    }
}

public class StudentTests
{
    [Fact]
    public void Student_GetCourses_ReturnsFormattedString()
    {
        // Arrange
        var student = new Student("Alice", "Smith", 20);
        var course = new OnlineCourse("C# Basics", "Introduction to C#");
        student.AddCourse(course);

        // Act
        var result = student.GetCourses();

        // Assert
        Assert.Equal("Студент записан на курсы: C# Basics", result);
    }

    [Fact]
    public void Student_SchoolProperty_CanBeSet()
    {
        // Arrange
        var student = new Student("Alice", "Smith", 20);

        // Act
        student.School = "School #1";

        // Assert
        Assert.Equal("School #1", student.School);
    }
}

public class TeacherTests
{
    [Fact]
    public void Teacher_GetCourses_ReturnsFormattedString()
    {
        // Arrange
        var teacher = new Teacher("Bob", "Johnson", 35);
        var course = new OnlineCourse("C# Basics", "Introduction to C#");
        teacher.AddCourse(course);

        // Act
        var result = teacher.GetCourses();

        // Assert
        Assert.Equal("Преподаватель ведет курсы: C# Basics", result);
    }

    [Fact]
    public void Teacher_WorkStageProperty_CanBeSet()
    {
        // Arrange
        var teacher = new Teacher("Bob", "Johnson", 35);

        // Act
        teacher.WorkStage = 10;

        // Assert
        Assert.Equal(10, teacher.WorkStage);
    }
}