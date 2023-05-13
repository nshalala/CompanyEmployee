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

    public void Delete(int id)
    {
        var department = DBContext.Departments.Find(dep => dep.DepartmentId == id);
        DBContext.Departments.Remove(department);
    }

    public void Update(Department entity)
    {
        var department = DBContext.Departments.Find(dep => dep.DepartmentId == entity.DepartmentId);
        department.Name = entity.Name;
        department.EmployeeLimit = entity.EmployeeLimit;
    }

    public Department GetById(int id)
    {
        return DBContext.Departments.Find(dep => dep.DepartmentId == id);
    }

    public List<Department> GetByName(string name)
    {
        return DBContext.Departments.FindAll(dep => dep.Name == name);
    }
}
