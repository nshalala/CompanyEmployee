using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Contexts;
using CompanyEmployee.DataAccess.Interfaces;

namespace CompanyEmployee.DataAccess.Implementations;

public class DepartmentRepository : IRepository<Department>
{
    public void Add(Department entity)
    {
        DBContext.Departments.Add(entity);
    }

    public void Delete(Department entity)
    {
        var department = DBContext.Departments.Find(dep => dep.DepartmentId == entity.DepartmentId);
        DBContext.Departments.Remove(department);
    }

    public void Update(int departmentId, string name, int employeeLimit)
    {
        var department = DBContext.Departments.Find(dep => dep.DepartmentId == departmentId);
        department.Name = name;
        department.EmployeeLimit = employeeLimit;
    }

    public Department GetById(int id)
    {
        return DBContext.Departments.Find(dep => dep.DepartmentId == id);
    }

    public Department GetByName(string name)
    {
        return DBContext.Departments.Find(dep => dep.Name == name);
    }

    public List<Employee> GetAllEmployees(int depId)
    {
        return DBContext.Employees.FindAll(emp => emp.DepartmentId == depId);
    }

    public List<Department> GetAll(int skip, int take)
    {
        return DBContext.Departments.GetRange(skip, take);
    }

    public List<Department> GetAllByName(string name)
    {
        return DBContext.Departments.FindAll(dep => dep.Name.Equals(name));
    }
}
