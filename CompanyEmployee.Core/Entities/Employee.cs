using CompanyEmployee.Core.Interfaces;

namespace CompanyEmployee.Core.Entities;

public class Employee : IEntity
{
    private static int _id;
    public int EmployeeId { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Salary { get; set; }
    public int DepartmentId { get; set; }

    //private Employee()
    //{
    //    Id = _id;
    //    _id++;
    //}

    public Employee(string name, string surname, int salary)/*:this()*/
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
