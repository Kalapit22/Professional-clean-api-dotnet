using System.Collections;
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {


    protected readonly TiendaContext _context;

    public GenericRepository(TiendaContext context) {
        _context = context;
    }


    public virtual void Add(T entity) {
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities) {
        _context.Set<T>().AddRange(entities);
    }

    public virtual void Update(T entity) {
        _context.Set<T>().Update(entity);
    }

    public virtual void Remove(T entity) {
        _context.Set<T>().Remove(entity);

    }


    public virtual void RemoveRange(IEnumerable<T> entities) {
        _context.Set<T>().RemoveRange(entities);
    }


    public async Task<IEnumerable<T>> GetAllAsync() {
        return await _context.Set<T>().ToListAsync();

    }


    public async Task<T> GetByIdAsync(int id) {
        return await _context.Set<T>().FindAsync(id);
    }
    
    public IEnumerable<T> Find(Expression<Func<T,bool>> expression) {
        return _context.Set<T>().Where(expression);
    }




}