
using System;

enum Department
{
    ComputerScience,
    ElectricalEngineering,
    MechanicalEngineering,
    Mathematics,
    Physics
}

class Person
{
    private string name;

    public Person()
    {
        name = null;
    }

    public Person(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

class Student : Person
{
    private string regNo;
    private int age;
    private Department program;

    public Student()
        : base() 
    {
        regNo = null; 
        age = 0;      
        program = Department.ComputerScience; 
    }

    public Student(string name, string regNo, int age, Department program)
        : base(name) // Call base class constructor
    {
        this.regNo = regNo;
        this.age = age;
        this.program = program;
    }

    // Properties for 'regNo', 'age', and 'program'
    public string RegNo
    {
        get { return regNo; }
        set { regNo = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Department Program
    {
        get { return program; }
        set { program = value; }
    }
}

class Program
{
    static void Main()
    {
        // Creating a Student object
        Student student1 = new Student("John Doe", "2023001", 20, Department.ComputerScience);

        // Accessing properties
        Console.WriteLine("Name: " + student1.Name);
        Console.WriteLine("Registration Number: " + student1.RegNo);
        Console.WriteLine("Age: " + student1.Age);
        Console.WriteLine("Program: " + student1.Program);
    }
}


