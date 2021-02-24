using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ITerritoryService
    {
        IResult Add(Territory territory);
        IResult AddAsync(Territory territory);

        IResult Update(Territory territory);
        IResult UpdateAsync(Territory territory);

        IResult Delete(Territory territory);
        IResult DeleteAsync(Territory territory);
               
        IDataResult<Territory> Get(Expression<Func<Territory, bool>> filter);
        IDataResult<Territory> GetAsync(Expression<Func<Territory, bool>> filter);

        IDataResult<List<Territory>> GetAll(Expression<Func<Territory, bool>> filter = null);
        IDataResult<List<Territory>> GetAllAsync(Expression<Func<Territory, bool>> filter = null);
    }
}
