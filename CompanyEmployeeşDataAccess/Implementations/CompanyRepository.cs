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

    public void Delete(int id)
    {
        var company = DBContext.Companies.Find(comp => comp.CompanyId == id);
        DBContext.Companies.Remove(company);
    }

    public void Update(Company entity)
    {
        var company = DBContext.Companies.Find(comp => comp.CompanyId == entity.CompanyId);
        company.Name = entity.Name;
    }

    public Company GetById(int id)
    {
        return DBContext.Companies.Find(comp => comp.CompanyId == id);
    }

    public List<Company> GetByName(string name)
    {
        return DBContext.Companies.FindAll(comp => comp.Name == name);
    }
 
}
