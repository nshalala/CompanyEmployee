using CompanyEmployee.Core.Interfaces;
using System.Security.Principal;

namespace CompanyEmployee.DataAccess.Interfaces;

public interface IRepository<T> where T : IEntity
{
    void Add(T entity);
    void Delete(int id);
    void Update(T entity);
    T GetById(int id);
    List<T> GetAll(int skip, int take);
}
