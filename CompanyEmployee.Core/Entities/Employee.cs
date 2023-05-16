using CompanyEmployee.Core.Interfaces;

namespace CompanyEmployee.Core.Entities;

public class Employee : IEntity
{
    private static int _id;
    public int EmployeeId { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public double Salary { get; set; }
    public int DepartmentId { get; set; }
    public DateTime StartDate { get; set; }

    public Employee(string name, string surname, double salary)
    {
        Name = name;
        Surname = surname;
        Salary = salary;
        EmployeeId = _id;
        _id++;
    }

    public override string ToString()
    {
        return $"{Name} {Surname}, Id: {EmployeeId}";
    }
}
