using Application.Contracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext RepositoryContext { get; set; }

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }

    public Task<IQueryable<T>> FindAll() => Task.FromResult(RepositoryContext.Set<T>().AsNoTracking());

    public Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression) =>
       Task.FromResult(RepositoryContext.Set<T>()
       .AsNoTracking()
       .Where(expression));

    public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

    public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

    public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
}