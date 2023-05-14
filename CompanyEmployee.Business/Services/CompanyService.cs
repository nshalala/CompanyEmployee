using CompanyEmployee.Business.Exceptions;
using CompanyEmployee.Business.Helpers;
using CompanyEmployee.Business.Interfaces;
using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Contexts;
using CompanyEmployee.DataAccess.Implementations;

namespace CompanyEmployee.Business.Services;

public class CompanyService : ICompanyService
{
    public CompanyRepository companyRepository { get; }

    public CompanyService()
    {
        companyRepository = new CompanyRepository();
    }
    public void Create(string compName)
    {
        string name = compName.Trim();
        if (string.IsNullOrEmpty(name))
        {
            throw new SizeException(Helper.Exceptions["SizeException"]);
        }
        var exists = DBContext.Companies.Find(comp => comp.Name.Equals(name));
        if(exists != null)
        {
            throw new AlreadyExistsException(Helper.Exceptions["AlreadyExistsException"]);
        }
        if(!name.IsOnlyLetters())
        {
            throw new InvalidWordException(Helper.Exceptions["InvalidWordException"]);
        }
        Company company = new Company(name);
        companyRepository.Add(company);
    }

    public void Delete(string compName)
    {
        string name = compName.Trim();
        var company = companyRepository.GetByName(name);
        if (company == null)
        {
            throw new NotFoundException($"{name} - doesn't exist.");
        }
        var departments = companyRepository.GetAllDepartments(company.CompanyId);
        if(departments.Count != 0)
        {
            throw new NotEmptyException(Helper.Exceptions["NotEmptyException"]);
        }
        companyRepository.Delete(company);
    }
    public void Update(int compId, string compName)
    {
        string name = compName.Trim();
        if (!string.IsNullOrEmpty(name))
        {
            throw new SizeException(Helper.Exceptions["SizeException"]);
        }
        var company = companyRepository.GetById(compId);
        if (company == null)
        {
            throw new NotFoundException($"{name} - doesn't exist.");
        }
        companyRepository.Update(company);
    }

    public List<Department> GetAllDepartments(int compId)
    {
        var company = companyRepository.GetById(compId);
        if (company == null)
        {
            throw new NotFoundException($"{company.Name} - doesn't exist.");
        }
        return companyRepository.GetAllDepartments(compId);
    }

    public List<Company> GetAll(int skip, int take)
    {
        if(skip < 0 || take < 0 || skip >= take)
        {
            throw new ArgumentOutOfRangeException("Entered values should not exceed the total amount and should be non-negative.");
        }
        return companyRepository.GetAll(skip, take);
    }

    public List<Company> GetAllByName(string compName)
    {
        var name = compName.Trim();
        if (string.IsNullOrEmpty(name))
        {
            throw new SizeException(Helper.Exceptions["SizeException"]);
        }
        return companyRepository.GetAllByName(name);
    }
}
