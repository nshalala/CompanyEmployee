using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Implementations;

namespace CompanyEmployee.Business.Interfaces;

public interface IDepartmentService
{
    public void Create(string name, int employeeLimit, int companyId);
    public void Delete(int departmentId);
    public void Update(Department department);
}
