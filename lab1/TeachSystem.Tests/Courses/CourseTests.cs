using TeachSystem.Courses;
using TeachSystem.Persons;
using TeachSystem.Interfaces;

namespace TeachSystem.Tests.Courses;

public class CourseTests
{
    [Fact]
    public void Course_Constructor_SetsPropertiesCorrectly()
    {
        // Arrange & Act
        var course = new TestCourse("C# Basics", "Introduction to C#");

        // Assert
        Assert.Equal("C# Basics", course.Name);
        Assert.Equal("Introduction to C#", course.Description);
        Assert.Equal("Base", course.Format);
    }

    [Fact]
    public void AddStudent_ValidStudent_AddsStudentSuccessfully()
    {
        // Arrange
        var course = new TestCourse("C# Basics", "Introduction to C#");
        var student = new Student("Alice", "Smith", 20);

        // Act
        course.AddStudent(student);

        // Assert
        Assert.Contains(student, course.GetStudentsInternal());
    }

    [Fact]
    public void AddStudent_NullStudent_ThrowsArgumentNullException()
    {
        // Arrange
        var course = new TestCourse("C# Basics", "Introduction to C#");

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => course.AddStudent(null));
        Assert.Equal("student", exception.ParamName);
    }

    [Fact]
    public void AddStudent_DuplicateStudent_ThrowsInvalidOperationException()
    {
        // Arrange
        var course = new TestCourse("C# Basics", "Introduction to C#");
        var student = new Student("Alice", "Smith", 20);
        course.AddStudent(student);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => course.AddStudent(student));
    }

    [Fact]
    public void RemoveStudent_ExistingStudent_ReturnsTrueAndRemovesStudent()
    {
        // Arrange
        var course = new TestCourse("C# Basics", "Introduction to C#");
        var student = new Student("Alice", "Smith", 20);
        course.AddStudent(student);

        // Act
        var result = course.RemoveStudent(student);

        // Assert
        Assert.True(result);
        Assert.DoesNotContain(student, course.GetStudentsInternal());
    }

    [Fact]
    public void RemoveStudent_NonExistingStudent_ReturnsFalse()
    {
        // Arrange
        var course = new TestCourse("C# Basics", "Introduction to C#");
        var student = new Student("Alice", "Smith", 20);

        // Act
        var result = course.RemoveStudent(student);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddTeacher_ValidTeacher_AddsTeacherSuccessfully()
    {
        // Arrange
        var course = new TestCourse("C# Basics", "Introduction to C#");
        var teacher = new Teacher("Bob", "Johnson", 35);

        // Act
        course.AddTeacher(teacher);

        // Assert
        Assert.Contains(teacher, course.GetTeachersInternal());
    }

    [Fact]
    public void GetStudents_NoStudents_ReturnsNoStudentsMessage()
    {
        // Arrange
        var course = new TestCourse("C# Basics", "Introduction to C#");

        // Act
        var result = course.GetStudents();

        // Assert
        Assert.Equal("Никто ещё не записан на курс", result);
    }

    [Fact]
    public void GetStudents_WithStudents_ReturnsStudentsList()
    {
        // Arrange
        var course = new TestCourse("C# Basics", "Introduction to C#");
        var student1 = new Student("Alice", "Smith", 20);
        var student2 = new Student("John", "Doe", 22);
        course.AddStudent(student1);
        course.AddStudent(student2);

        // Act
        var result = course.GetStudents();

        // Assert
        Assert.Contains("Alice", result);
        Assert.Contains("John", result);
        Assert.Contains("На курс записаны: Alice, John", result);
    }

    // Test class to access protected members
    private class TestCourse : Course
    {
        public TestCourse(string name, string description = "") : base(name, description) { }

        public List<IStudent> GetStudentsInternal() => _students;
        public List<ITeacher> GetTeachersInternal() => _teachers;
    }
}

public class OfflineCourseTests
{
    [Fact]
    public void OfflineCourse_Format_ReturnsOffline()
    {
        // Arrange & Act
        var course = new OfflineCourse("Algorithms", "Basic algorithms");

        // Assert
        Assert.Equal("Офлайн", course.Format);
    }

    [Fact]
    public void OfflineCourse_Properties_CanBeSet()
    {
        // Arrange
        var course = new OfflineCourse("Algorithms", "Basic algorithms");

        // Act
        course.Place = "Main Building";
        course.Cabinet = "Room 301";

        // Assert
        Assert.Equal("Main Building", course.Place);
        Assert.Equal("Room 301", course.Cabinet);
    }
}

public class OnlineCourseTests
{
    [Fact]
    public void OnlineCourse_Format_ReturnsOnline()
    {
        // Arrange & Act
        var course = new OnlineCourse("C# Basics", "Introduction to C#");

        // Assert
        Assert.Equal("Онлайн", course.Format);
    }

    [Fact]
    public void OnlineCourse_Properties_CanBeSet()
    {
        // Arrange
        var course = new OnlineCourse("C# Basics", "Introduction to C#");

        // Act
        course.Platform = "Zoom";
        course.Permalink = "https://zoom.us/j/123456";

        // Assert
        Assert.Equal("Zoom", course.Platform);
        Assert.Equal("https://zoom.us/j/123456", course.Permalink);
    }
}