using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRegionService
    {
        IResult Add(Region region);
        IResult AddAsync(Region region);

        IResult Update(Region region);
        IResult UpdateAsync(Region region);

        IResult Delete(Region region);
        IResult DeleteAsync(Region region);

        IDataResult<Region> Get(Expression<Func<Region, bool>> filter);
        IDataResult<Region> GetAsync(Expression<Func<Region, bool>> filter);

        IDataResult<List<Region>> GetAll(Expression<Func<Region, bool>> filter = null);
        IDataResult<List<Region>> GetAllAsync(Expression<Func<Region, bool>> filter = null);
    }
}
