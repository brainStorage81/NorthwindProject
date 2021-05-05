using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService 
    {
        IResult Add(Category category);
        IResult AddAsync(Category category);
        IResult TransactionalOperation(Category category);

        IResult Update(Category category);
        IResult UpdateAsync(Category category);

        IResult Delete(Category category);
        IResult DeleteAsync(Category category);

        IDataResult<Category>Get(Expression<Func<Category, bool>> filter);
        IDataResult<Category> GetAsync(Expression<Func<Category, bool>> filter);

        IDataResult<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null);
        IDataResult<List<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null);
    }
}
