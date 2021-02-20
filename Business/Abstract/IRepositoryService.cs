using Core.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRepositoryService<T> where T : class, new()
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        IDataResult<T> Get(Expression<Func<T, bool>> filter = null);

    }
}
