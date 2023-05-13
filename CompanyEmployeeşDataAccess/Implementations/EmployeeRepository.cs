using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Contexts;
using CompanyEmployee.DataAccess.Interfaces;

namespace CompanyEmployee.DataAccess.Implementations;

public class EmployeeRepository : IRepository<Employee>
{
    public void Add(Employee entity)
    {
        DBContext.Employees.Add(entity);
    }

    public void Delete(int id)
    {
        var employee = DBContext.Employees.Find(emp => emp.EmployeeId == id);
        DBContext.Employees.Remove(employee);
    }

    public void Update(Employee entity)
    {
        var employee =  DBContext.Employees.Find(emp => emp.EmployeeId == entity.EmployeeId);
        employee.Salary = entity.Salary;
        employee.Name = entity.Name;
        employee.Surname = entity.Surname;
    }

    public Employee GetById(int id)
    {
        return DBContext.Employees.Find(emp => emp.EmployeeId == id);
    }

    public List<Employee> GetAllByName(string name)
    { 
        return DBContext.Employees.FindAll(emp => emp.Name == name);
    }

    public List<Employee> GetAll(int skip, int take)
    {
        return DBContext.Employees.GetRange(skip, take);
    }

    public List<Employee> GetBySalaryRange(int min, int max)
    {
        return DBContext.Employees.FindAll(emp => emp.Salary >= min && emp.Salary <= max);
    }
}
