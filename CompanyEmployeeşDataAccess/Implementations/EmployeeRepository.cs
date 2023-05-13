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

    public List<Employee> GetByName(string name)
    {
        return DBContext.Employees.FindAll(emp => emp.Name == name);
    }
}
