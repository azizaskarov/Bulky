﻿using System.Linq.Expressions;

namespace Bulky.DataAccess.IRepositories;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T? Get(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}