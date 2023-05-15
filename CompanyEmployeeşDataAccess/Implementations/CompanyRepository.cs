using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Contexts;
using CompanyEmployee.DataAccess.Interfaces;

namespace CompanyEmployee.DataAccess.Implementations;

public class CompanyRepository : IRepository<Company>
{
    public void Add(Company entity)
    {
        DBContext.Companies.Add(entity);
    }

    public void Delete(Company entity)
    {
        var company = DBContext.Companies.Find(comp => comp.CompanyId == entity.CompanyId);
        DBContext.Companies.Remove(company);
    }

    public void Update(int id, Company entity)
    {
        var company = DBContext.Companies.Find(comp => comp.CompanyId == id);
        company.Name = entity.Name;
    }

    public Company GetById(int id)
    {
        return DBContext.Companies.Find(comp => comp.CompanyId == id);
    }

    public Company GetByName(string name)
    {
        return DBContext.Companies.Find(comp => comp.Name.Equals(name));
    }

    public List<Department> GetAllDepartments(int id)
    {
        return DBContext.Departments.FindAll(dep => dep.CompanyId == id);
    }

    public List<Company> GetAll(int skip, int take)
    {
        return DBContext.Companies.GetRange(skip, take);
    }

    public List<Company> GetAllByName(string name)
    {
        return DBContext.Companies.FindAll(comp => comp.Name.Equals(name));
    }
}
