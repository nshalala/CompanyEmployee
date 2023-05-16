using CompanyEmployee.Business.Exceptions;
using CompanyEmployee.Business.Helpers;
using CompanyEmployee.Business.Interfaces;
using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Contexts;
using CompanyEmployee.DataAccess.Implementations;

namespace CompanyEmployee.Business.Services;

public class EmployeeService : IEmployeeService
{
    public EmployeeRepository employeeRepository { get; }
    public DepartmentRepository departmentRepository { get; }
    public EmployeeService()
    {
        employeeRepository = new();
    }
    public void Create(string empName, string empSurname, double salary)
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
        employee.StartDate = DateTime.Now;
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

    public List<Employee> GetAll(int skip, int take)
    {
        int maxValue = DBContext.Employees.Count;
        if (skip < 0 || take < 0 || skip+take >= maxValue)
        {
            throw new ArgumentOutOfRangeException("Entered values should not exceed the total amount and should be non-negative.");
        }
        return employeeRepository.GetAll(skip, take);
    }

    public List<Employee> GetAllByName(string empName)
    {
        var name = empName.Trim();
        if (string.IsNullOrEmpty(name))
        {
            throw new SizeException(Helper.Exceptions["SizeException"]);
        }
        return employeeRepository.GetAllByName(name);
    }

    public List<Employee> GetBySalaryRange(int min, int max)
    {
        if (min <= 0 || max <= 0)
        {
            throw new NegativeValueException(Helper.Exceptions["NegativeValueException"]);
        }
        if (max < min)
        {
            throw new ArgumentException("Max value should be bigger than min value.");
        }
        return employeeRepository.GetBySalaryRange(min, max);
    }

    public void Update(int employeeId, string empName, string empSurname, double salary)
    {
        var oldData = employeeRepository.GetById(employeeId);
        if (oldData == null)
        {
            throw new NotFoundException("Employee not found.");
        }
        var name = empName.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new NullReferenceException("Employee name cannot be empty or white space.");
        }
        if (!name.IsOnlyLetters())
        {
            throw new InvalidWordException(Helper.Exceptions["InvalidWordException"]);
        }
        var surname = empSurname.Trim().ToLower();
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
        Employee employee = new Employee(name, surname, salary);
        employeeRepository.Update(employeeId, employee);
    }

    public Employee GetById(int employeeId)
    {
        var emp = employeeRepository.GetById(employeeId);
        if (emp == null)
        {
            throw new NotFoundException("Employee not found.");
        }
        return emp;
    }

    public void Transfer(int empId,  int newDepId)
    {
        var emp = employeeRepository.GetById(empId); 
        if (emp == null)
        {
            throw new NotFoundException("Employee not found.");
        }
        var dep = departmentRepository.GetById(newDepId); 
        if (dep == null)
        {
            throw new NotFoundException("Department not found.");
        }
        emp.DepartmentId = newDepId;
    }

    public int WorkingExperience(DateTime startDate)
    {
        DateTime currentDate = DateTime.Now;
        int monthsPassed = ((currentDate.Year - startDate.Year) * 12) + currentDate.Month - startDate.Month;
        return monthsPassed;
    }
}
