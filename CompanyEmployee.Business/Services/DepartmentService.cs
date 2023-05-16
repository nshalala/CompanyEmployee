using CompanyEmployee.Business.Exceptions;
using CompanyEmployee.Business.Helpers;
using CompanyEmployee.Business.Interfaces;
using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Contexts;
using CompanyEmployee.DataAccess.Implementations;

namespace CompanyEmployee.Business.Services;

public class DepartmentService : IDepartmentService
{
    public EmployeeRepository employeeRepository { get; }
    public DepartmentRepository departmentRepository { get; }
    public CompanyRepository companyRepository { get; }

    public DepartmentService()
    {
        employeeRepository = new EmployeeRepository();
        departmentRepository = new DepartmentRepository();
        companyRepository = new CompanyRepository();
    }

    public void Create(string depName, int empLimit, int compId)
    {
        string name = depName.Trim().ToLower();
        bool compExists = DBContext.Companies.Any(comp => comp.CompanyId == compId);
        if (!compExists)
        {
            throw new NotFoundException($"Such company doesn't exist.");
        }
        var depExists = companyRepository.GetAllDepartments(compId).Any(dep => dep.Name == name);
        if (depExists)
        {
            throw new AlreadyExistsException(Helper.Exceptions["AlreadyExistsException"]);
        }
        if (empLimit < 1)
        {
            throw new TooLowException(Helper.Exceptions["TooLowException"]);
        }
        Department department = new Department(name, compId, compId);
        departmentRepository.Add(department);
    }

    public void Delete(int departmentId)
    {
        var department = departmentRepository.GetById(departmentId);
        if (department == null)
        {
            throw new NotFoundException($"Such department doesn't exist.");
        }
        int count = departmentRepository.GetAllEmployees(departmentId).Count;
        if (count != 0)
        {
            throw new NotEmptyException(Helper.Exceptions["NotEmptyException"]);
        }
        departmentRepository.Delete(department);
    }

    public void Update(int depId, string depName, int empLimit)
    {
        var depCheck = departmentRepository.GetById(depId);
        if (depCheck == null)
        {
            throw new NotFoundException("Such department doesn't exist.");
        }
        string name = depName.Trim().ToLower();
        if (string.IsNullOrEmpty(name))
        {
            throw new NullReferenceException("Department name cannot be empty or white space.");
        }
        int empCount = departmentRepository.GetAllEmployees(depId).Count;
        if (empLimit < empCount)
        {
            throw new TooLowException(Helper.Exceptions["TooLowException"]);
        }
        Department department = new Department(name, empLimit, depCheck.CompanyId);
        departmentRepository.Update(depId, department);
    }
    

    public List<Department> GetAll(int skip, int take)
    {
        int maxvalue = DBContext.Departments.Count;
        if (skip < 0 || take < 0 || skip + take > maxvalue)
        {
            throw new ArgumentOutOfRangeException("Entered values should not exceed the total amount and should be non-negative.");
        }
        return departmentRepository.GetAll(skip, take);
    }
    public List<Department> GetAllByName(string depName)
    {
        var name = depName.Trim().ToLower();
        if (string.IsNullOrEmpty(name))
        {
            throw new SizeException(Helper.Exceptions["SizeException"]);
        }
        return departmentRepository.GetAllByName(name);
    }

    public void AddEmployee(Department department, Employee employee)
    {
        int count = departmentRepository.GetAllEmployees(department.DepartmentId).Count;
        if(count == department.EmployeeLimit)
        {
            throw new CapacityLimitException(Helper.Exceptions["CapacityLimitException"]);
        }
        var emp = employeeRepository.GetById(employee.EmployeeId);
        if (emp == null)
        {
            throw new NotFoundException("Employee not found.");
        }
        departmentRepository.AddEmployee(department, employee);
    }

    public Department GetById(int departmentId)
    {
        var dep = departmentRepository.GetById(departmentId);
        if(dep == null)
        {
            throw new NotFoundException("Department not found.");
        }
        return dep;
    }
}
