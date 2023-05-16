using CompanyEmployee.Core.Entities;

namespace CompanyEmployee.Business.Interfaces;

public interface IEmployeeService
{
    void Create(string name, string surname, double salary);
    void Delete(int employeeId);
    void Update(int employeeId, string name, string surname, double salary);
    Employee GetById(int employeeId);
    List<Employee> GetAllByName(string name);
    List<Employee> GetAll(int skip, int take);
    List<Employee> GetBySalaryRange(int min, int max);

}
