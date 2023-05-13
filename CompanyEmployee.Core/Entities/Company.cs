using CompanyEmployee.Core.Interfaces;

namespace CompanyEmployee.Core.Entities;

public class Company : IEntity
{
    private static int _id;
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public Company(string name)
    {
        Name = name;
    }
}
