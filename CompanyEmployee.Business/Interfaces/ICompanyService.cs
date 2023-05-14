using CompanyEmployee.Core.Entities;

namespace CompanyEmployee.Business.Interfaces;

public interface ICompanyService
{
    void Create(string name);
    void Delete(string name);
    void Update(Company entity);
    List<Department> GetAllDepartments(int compId);
    List<Company> GetAll(int skip, int take);
    
}
