using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IShipperService
    {
        IResult Add(Shipper shipper);
        IResult AddAsync(Shipper shipper);

        IResult Update(Shipper shipper);
        IResult UpdateAsync(Shipper shipper);

        IResult Delete(Shipper shipper);
        IResult DeleteAsync(Shipper shipper);

        IDataResult<Shipper> Get(Expression<Func<Shipper, bool>> filter);
        IDataResult<Shipper> GetAsync(Expression<Func<Shipper, bool>> filter);

        IDataResult<List<Shipper>> GetAll(Expression<Func<Shipper, bool>> filter = null);
        IDataResult<List<Shipper>> GetAllAsync(Expression<Func<Shipper, bool>> filter = null);
    }
}
