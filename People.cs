// ������� ����� "�������"
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

// ����� "�������" ����������� �� ������ "�������"
class Student : Person
{
    public Student(string name, int age, string phoneNumber) : base(name, age, phoneNumber) { }
}

// ����� "��������" ����������� �� ������ "�������"
class GroupCaptain : Student
{
    public GroupCaptain(string name, int age, string phoneNumber) : base(name, age, phoneNumber) { }
}

// ����� "������"
class Group
{
    public List<Student> Students { get; set; }
    public GroupCaptain Captain { get; set; }

    public Group()
    {
        Students = new List<Student>();
    }
}

// ����� "����� ��������� ������"
class ViewMode
{
    public void DisplayStudentInfo(Student student)
    {
        Console.WriteLine($"���: {student.Name}");
        Console.WriteLine($"�������: {student.Age}");
        Console.WriteLine($"�������: {student.PhoneNumber}");
    }

    public void DisplayGroupInfo(Group group)
    {
        Console.WriteLine($"��������: {group.Captain.Name}");

        Console.WriteLine("��������:");
        foreach (var student in group.Students)
        {
            Console.WriteLine($"���: {student.Name}");
            Console.WriteLine($"�������: {student.Age}");
            Console.WriteLine($"�������: {student.PhoneNumber}");
        }
    }
}

// ����� "����� �������������� ������"
class EditMode : ViewMode
{
    public void EditStudentInfo(Student student, string name, int age, string phoneNumber)
    {
        student.Name = name;
        student.Age = age;
        student.PhoneNumber = phoneNumber;

        Console.WriteLine("������ � �������� ���������.");
    }

    public void EditGroupCaptainInfo(GroupCaptain captain, string name, int age, string phoneNumber)
    {
        captain.Name = name;
        captain.Age = age;
        captain.PhoneNumber = phoneNumber;

        Console.WriteLine("������ � �������� ���������.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("����������� ����", 20, "123456789");
        Student student2 = new Student("��������� �����", 19, "987654321");
        GroupCaptain captain = new GroupCaptain("������� �����", 22, "111222333");

        Group group = new Group();
        group.Students.Add(student1);
        group.Students.Add(student2);
        group.Captain = captain;

        ViewMode viewMode = new ViewMode();
        viewMode.DisplayGroupInfo(group);

        EditMode editMode = new EditMode();
        editMode.EditStudentInfo(student1, "����������� ���� ����������", 21, "111222333");
        editMode.EditGroupCaptainInfo(captain, "������� ����� �������������", 23, "123456789");

        viewMode.DisplayGroupInfo(group);
    }
}
