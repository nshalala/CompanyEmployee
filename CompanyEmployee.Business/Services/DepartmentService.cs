using CompanyEmployee.Business.Exceptions;
using CompanyEmployee.Business.Exceptionsı;
using CompanyEmployee.Business.Helpers;
using CompanyEmployee.Business.Interfaces;
using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Contexts;
using CompanyEmployee.DataAccess.Implementations;

namespace CompanyEmployee.Business.Services;

public class DepartmentService : IDepartmentService
{
    public DepartmentRepository departmentRepository { get; set; }
    public CompanyRepository companyRepository { get; set; }

    public void Create(string name, int employeeLimit, int companyId)
    {
        var compExists = companyRepository.GetById(companyId);
        if (compExists == null)
        {
            throw new NotFoundException(Helper.Exceptions["NotFoundException"]);
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
        var depExists = departmentRepository.GetById(departmentId);
        if(depExists == null)
        {
            throw new NotFoundException(Helper.Exceptions["NotFoundException"]);
        }
        var containsEmp = departmentRepository.GetAllEmployees(departmentId);
        if(containsEmp.Count != 0)
        {
            throw new NotEmptyException(Helper.Exceptions["NotEmptyException"]);
        }
        departmentRepository.Delete(departmentId);
    }

    public void Update(Department department)
    {
        var depExists = departmentRepository.GetById(department.DepartmentId);
        if( depExists == null)
        {
            throw new NotFoundException(Helper.Exceptions["NotFoundException"]);
        }
        int empCount = departmentRepository.GetAllEmployees(department.DepartmentId).Count;
        if(department.EmployeeLimit < empCount)
        {
            throw new TooLowException(Helper.Exceptions["TooLowException"]);
        }
        departmentRepository.Update(department);
    }
}
