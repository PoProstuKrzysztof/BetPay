﻿using System.Linq.Expressions;

namespace Application.Contracts;

public interface IRepositoryBase<T>
{
    Task<IQueryable<T>> FindAll();

    Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression);

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);
}