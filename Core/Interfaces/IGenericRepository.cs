using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;


// Solo se puede usar con clase de Dominio, Entities
public interface IGenericRepository<T> where T : BaseEntity {

    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    // Regresa un conjunto de registros dado una expresion LINQ (Where)
    IEnumerable<T> Find(Expression<Func<T,bool>> expression);

    void Add (T entity);

    void AddRange (IEnumerable<T> entities);

    void Remove (T entity);

    void RemoveRange  (IEnumerable<T> entities);

    void Update (T entity);
    
    //Task<T> FindLast(Expression<Func<T,bool>> expression);

}
