using CompanyEmployee.Business.Exceptions;
using CompanyEmployee.Business.Helpers;
using CompanyEmployee.Business.Interfaces;
using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Implementations;

namespace CompanyEmployee.Business.Services;

public class EmployeeService : IEmployeeService
{
    public EmployeeRepository employeeRepository { get; }
    public EmployeeService()
    {
        employeeRepository = new();
    }
    public void Create(string empName, string empSurname, int salary)
    {
        var name = empName.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new SizeException(Helper.Exceptions["SizeException"]);
        }
        if (!name.IsOnlyLetters())
        {
            throw new InvalidWordException(Helper.Exceptions["InvalidWordException"]);
        }
        var surname = empSurname.Trim();
        if (!string.IsNullOrWhiteSpace(surname))
        {
            if (!name.IsOnlyLetters())
            {
                throw new InvalidWordException(Helper.Exceptions["InvalidWordException"]);
            }
        }
        if (salary < 300)
        {
            throw new TooLowException(Helper.Exceptions["TooLowException"]);
        }
        Employee employee = new Employee(name, surname, salary);
        employeeRepository.Add(employee);
    }

    public void Delete(int employeeId)
    {
        var employee = employeeRepository.GetById(employeeId);
        if (employee == null)
        {
            throw new NotFoundException("Employee doesn't exist.");
        }
        employeeRepository.Delete(employee);
    }

    public void GetAll(int skip, int take)
    {
        if (skip < 0 || take < 0 || skip >= take)
        {
            throw new ArgumentOutOfRangeException("Entered values should not exceed the total amount and should be non-negative.");
        }
        employeeRepository.GetAll(skip, take);
    }

    public void GetAllByName(string empName)
    {
        var name = empName.Trim();
        if (string.IsNullOrEmpty(name))
        {
            throw new SizeException(Helper.Exceptions["SizeException"]);
        }
        employeeRepository.GetAllByName(name);
    }

    public void GetBySalaryRange(int min, int max)
    {
        if (min <= 0 || max <= 0)
        {
            throw new NegativeValueException(Helper.Exceptions["NegativeValueException"]);
        }
        if (max < min)
        {
            throw new ArgumentException("Max value should be bigger than min value.");
        }
        employeeRepository.GetBySalaryRange(min, max);
    }

    public void Update(int employeeId, string empName, string empSurname, int salary)
    {
        var oldData = employeeRepository.GetById(employeeId);
        if (oldData == null)
        {
            throw new NotFoundException("Employee not found.");
        }
        var name = empName.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new SizeException(Helper.Exceptions["SizeException"]);
        }
        if (!name.IsOnlyLetters())
        {
            throw new InvalidWordException(Helper.Exceptions["InvalidWordException"]);
        }
        var surname = empSurname.Trim();
        if (!string.IsNullOrWhiteSpace(surname))
        {
            if (!surname.IsOnlyLetters())
            {
                throw new InvalidWordException(Helper.Exceptions["InvalidWordException"]);
            }
        }
        if (salary < 300)
        {
            throw new TooLowException(Helper.Exceptions["TooLowException"]);
        }
        employeeRepository.Update(employeeId, name, surname, salary);
    }
}
