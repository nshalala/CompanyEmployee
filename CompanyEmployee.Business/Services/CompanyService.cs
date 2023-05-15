using CompanyEmployee.Business.Exceptions;
using CompanyEmployee.Business.Helpers;
using CompanyEmployee.Business.Interfaces;
using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Contexts;
using CompanyEmployee.DataAccess.Implementations;
using System.Xml.Linq;

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
        string name = compName.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new NullReferenceException("Company name cannot be empty or white space.");
        }
        bool exists = DBContext.Companies.Any(comp => comp.Name.Equals(name));
        if (exists)
        {
            throw new AlreadyExistsException(Helper.Exceptions["AlreadyExistsException"]);
        }
        Company company = new Company(name);
        companyRepository.Add(company);
    }

    public void Delete(string compName)
    {
        string name = compName.Trim().ToLower();
        var company = companyRepository.GetByName(name);
        if (company == null)
        {
            throw new NotFoundException($"{name} - doesn't exist.");
        }
        int count = companyRepository.GetAllDepartments(company.CompanyId).Count;
        if (count != 0)
        {
            throw new NotEmptyException(Helper.Exceptions["NotEmptyException"]);
        }
        companyRepository.Delete(company);
    }
    public void Update(int compId, string compName)
    {
        string name = compName.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new NullReferenceException("Company name cannot be empty or white space.");
        }
        var compCheck = companyRepository.GetById(compId);
        if (compCheck == null)
        {
            throw new NotFoundException($"Such company doesn't exist.");
        }
        Company company = new Company(name);
        companyRepository.Update(compId, company);
    }

    public List<Department> GetAllDepartments(int compId)
    {
        bool exists = DBContext.Companies.Any(comp => comp.CompanyId == compId);
        if (!exists)
        {
            throw new NotFoundException("Such company doesn't exist.");
        }
        return companyRepository.GetAllDepartments(compId);
    }

    public List<Company> GetAll(int skip, int take)
    {
        int maxValue = DBContext.Companies.Count;
        if (skip < 0 || take < 0 || skip + take > maxValue)
        {
            throw new ArgumentOutOfRangeException("Entered values should not exceed the total amount and should be non-negative.");
        }
        return companyRepository.GetAll(skip, take);
    }

    public List<Company> GetAllByName(string compName)
    {
        var name = compName.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new NullReferenceException("Company name cannot be empty or white space.");
        }
        return companyRepository.GetAllByName(name);
    }
}
