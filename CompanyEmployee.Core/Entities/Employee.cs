﻿using CompanyEmployee.Core.Interfaces;

namespace CompanyEmployee.Core.Entities;

public class Employee : IEntity
{
    private static int _id;
    public int EmployeeId { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Salary { get; set; }
    public int DepartmentId { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public Employee(string name, string surname, int salary)
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
