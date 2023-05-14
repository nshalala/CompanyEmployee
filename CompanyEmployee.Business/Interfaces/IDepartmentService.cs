using CompanyEmployee.Core.Entities;

namespace CompanyEmployee.Business.Interfaces;

public interface IDepartmentService
{
    public void Create(string name, int employeeLimit, int companyId);
    public void Delete(int departmentId);
    public void Update(int departmentId, string departmentName, int employeeLimit);
    public List<Department> GetAll(int skip, int take);
    public List<Department> GetAllByName(string name);

}
