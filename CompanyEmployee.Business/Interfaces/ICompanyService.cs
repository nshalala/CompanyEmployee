using CompanyEmployee.Core.Entities;

namespace CompanyEmployee.Business.Interfaces;

public interface ICompanyService
{
    void Create(string companyName);
    void Delete(string companyName);
    void Update(int companyId, string companyName);
    List<Department> GetAllDepartments(int companyId);
    List<Company> GetAll(int skip, int take);
}
