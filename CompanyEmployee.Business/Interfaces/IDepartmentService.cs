using CompanyEmployee.Core.Entities;

namespace CompanyEmployee.Business.Interfaces;

public interface IDepartmentService
{
    void Create(string name, int employeeLimit, int companyId);
    void Delete(int departmentId);
    void Update(int departmentId, string departmentName, int employeeLimit);
    Department GetById(int departmentId);
    List<Department> GetAll(int skip, int take);
    List<Department> GetAllByName(string name);
    void AddEmployee(Department department, Employee employee);

}
