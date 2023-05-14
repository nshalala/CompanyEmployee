using CompanyEmployee.Business.Exceptions;
using CompanyEmployee.Business.Exceptionsı;
using CompanyEmployee.Business.Helpers;
using CompanyEmployee.Business.Interfaces;
using CompanyEmployee.Core.Entities;
using CompanyEmployee.DataAccess.Contexts;
using CompanyEmployee.DataAccess.Implementations;

namespace CompanyEmployee.Business.Services;

public class CompanyService : ICompanyService
{
    public CompanyRepository companyRepository { get; set; }
    public void Create(string name)
    {
        var exists = DBContext.Companies.Find(comp => comp.Name.Equals(name));
        if(exists != null)
        {
            throw new AlreadyExistsException(Helper.Exceptions["AlreadyExistsException"]);
        }
        string compName = name.Trim();
        if(!compName.IsOnlyLetters())
        {
            throw new InvalidWordException(Helper.Exceptions["InvalidWordException"]);
        }
        Company company = new Company(compName);
        companyRepository.Add(company);
    }

    public void Delete(string compName)
    {
        var company = companyRepository.GetByName(compName);
        if (company == null)
        {
            throw new NotFoundException($"{compName} - doesn't exist.");
        }
        var departments = companyRepository.GetAllDepartments(company.CompanyId);
        if(departments.Count != 0)
        {
            throw new NotEmptyException(Helper.Exceptions["NotEmptyException"]);
        }
        companyRepository.Delete(company.CompanyId);
    }
    public void Update(Company entity)
    {
        var exists = companyRepository.GetByName(entity.Name);
        if (exists != null)
        {
            throw new NotFoundException($"{entity.Name} - doesn't exist.");
        }
        if (!string.IsNullOrEmpty(entity.Name))
        {
            throw new ArgumentNullException("Company name cannot be null.");
        }
        companyRepository.Update(entity);
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

}
