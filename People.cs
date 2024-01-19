// Базовый класс "Человек"
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }

    public Person(string name, int age, string phoneNumber)
    {
        Name = name;
        Age = age;
        PhoneNumber = phoneNumber;
    }
}

// Класс "Студент" наследуется от класса "Человек"
class Student : Person
{
    public Student(string name, int age, string phoneNumber) : base(name, age, phoneNumber) { }
}

// Класс "Староста" наследуется от класса "Студент"
class GroupCaptain : Student
{
    public GroupCaptain(string name, int age, string phoneNumber) : base(name, age, phoneNumber) { }
}

// Класс "Группа"
class Group
{
    public List<Student> Students { get; set; }
    public GroupCaptain Captain { get; set; }

    public Group()
    {
        Students = new List<Student>();
    }
}

// Класс "Режим просмотра данных"
class ViewMode
{
    public void DisplayStudentInfo(Student student)
    {
        Console.WriteLine($"Имя: {student.Name}");
        Console.WriteLine($"Возраст: {student.Age}");
        Console.WriteLine($"Телефон: {student.PhoneNumber}");
    }

    public void DisplayGroupInfo(Group group)
    {
        Console.WriteLine($"Староста: {group.Captain.Name}");

        Console.WriteLine("Студенты:");
        foreach (var student in group.Students)
        {
            Console.WriteLine($"Имя: {student.Name}");
            Console.WriteLine($"Возраст: {student.Age}");
            Console.WriteLine($"Телефон: {student.PhoneNumber}");
        }
    }
}

// Класс "Режим редактирования данных"
class EditMode : ViewMode
{
    public void EditStudentInfo(Student student, string name, int age, string phoneNumber)
    {
        student.Name = name;
        student.Age = age;
        student.PhoneNumber = phoneNumber;

        Console.WriteLine("Данные о студенте обновлены.");
    }

    public void EditGroupCaptainInfo(GroupCaptain captain, string name, int age, string phoneNumber)
    {
        captain.Name = name;
        captain.Age = age;
        captain.PhoneNumber = phoneNumber;

        Console.WriteLine("Данные о старосте обновлены.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Поликарпова Анна", 20, "123456789");
        Student student2 = new Student("Бондарчук Елена", 19, "987654321");
        GroupCaptain captain = new GroupCaptain("Сидоров Роман", 22, "111222333");

        Group group = new Group();
        group.Students.Add(student1);
        group.Students.Add(student2);
        group.Captain = captain;

        ViewMode viewMode = new ViewMode();
        viewMode.DisplayGroupInfo(group);

        EditMode editMode = new EditMode();
        editMode.EditStudentInfo(student1, "Поликарпова Анна Максимовна", 21, "111222333");
        editMode.EditGroupCaptainInfo(captain, "Сидоров Роман Александрович", 23, "123456789");

        viewMode.DisplayGroupInfo(group);
    }
}
