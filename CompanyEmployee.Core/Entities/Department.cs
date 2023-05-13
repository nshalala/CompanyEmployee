using CompanyEmployee.Core.Interfaces;

namespace CompanyEmployee.Core.Entities;

public class Department : IEntity
{
    private static int _id;
    public int DepartmentId { get; }
    public string Name { get; set; }
    public int EmployeeLimit { get; set; }
    public int CompanyId { get; set; }
    public Department(string name, int limit)
    {
        Name = name;
        EmployeeLimit = limit;
        DepartmentId = _id;
        _id++;
    }

    public override string ToString()
    {
        return $"{Name}, Id: {DepartmentId}";
    }
}
