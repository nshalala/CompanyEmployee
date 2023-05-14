using CompanyEmployee.Business.Exceptions;
using CompanyEmployee.Business.Helpers;
using CompanyEmployee.Business.Interfaces;
using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Implementations;

namespace CompanyEmployee.Business.Services;

public class DepartmentService : IDepartmentService
{
    public DepartmentRepository departmentRepository { get; }
    public CompanyRepository companyRepository { get; }

    public DepartmentService()
    {
        departmentRepository = new DepartmentRepository();
        companyRepository = new CompanyRepository();
    }

    public void Create(string depName, int employeeLimit, int companyId)
    {
        string name = depName.Trim();
        var compExists = companyRepository.GetById(companyId);
        if (compExists == null)
        {
            throw new NotFoundException($"{compExists.Name} - doesn't exist.");
        }
        var depExists = companyRepository.GetAllDepartments(companyId).Find(dep => dep.Name == name);
        if (depExists != null)
        {
            throw new AlreadyExistsException(Helper.Exceptions["AlreadyExistsException"]);
        }
        if (employeeLimit < 1)
        {
            throw new TooLowException(Helper.Exceptions["TooLowException"]);
        }
        Department department = new Department(name, employeeLimit, companyId);
        departmentRepository.Add(department);
    }

    public void Delete(int departmentId)
    {
        var department = departmentRepository.GetById(departmentId);
        if (department == null)
        {
            throw new NotFoundException($"{department.Name} - doesn't exist.");
        }
        var containsEmp = departmentRepository.GetAllEmployees(departmentId);
        if (containsEmp.Count != 0)
        {
            throw new NotEmptyException(Helper.Exceptions["NotEmptyException"]);
        }
        departmentRepository.Delete(department);
    }

    public void Update(int depId, string depName, int empLimit)
    {
        string name = depName.Trim();
        if (string.IsNullOrEmpty(name))
        {
            throw new SizeException(Helper.Exceptions["SizeException"]);
        }
        var department = departmentRepository.GetById(depId);
        if (department == null)
        {
            throw new NotFoundException("Corresponding department doesn't exist.");
        }
        int empCount = departmentRepository.GetAllEmployees(depId).Count;
        if (empLimit < empCount)
        {
            throw new TooLowException(Helper.Exceptions["TooLowException"]);
        }
        departmentRepository.Update(depId, name, empLimit);
    }

    public List<Department> GetAll(int skip, int take)
    {
        if (skip < 0 || take < 0 || skip >= take)
        {
            throw new ArgumentOutOfRangeException("Entered values should not exceed the total amount and should be non-negative.");
        }
        return departmentRepository.GetAll(skip, take);
    }
    public List<Department> GetAllByName(string depName)
    {
        var name = depName.Trim();
        if (string.IsNullOrEmpty(name))
        {
            throw new SizeException(Helper.Exceptions["SizeException"]);
        }
        return departmentRepository.GetAllByName(name);
    }
}
