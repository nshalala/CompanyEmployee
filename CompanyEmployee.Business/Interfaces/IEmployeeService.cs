using CompanyEmployee.Core.Entities;

namespace CompanyEmployee.Business.Interfaces;

public interface IEmployeeService
{
    void Create(string name, string surname, int salary);
    void Delete(int employeeId);
    void Update(int employeeId, string name, string surname, int salary);
    void GetAllByName(string name);
    void GetAll(int skip, int take);
    void GetBySalaryRange(int min, int max);

}
