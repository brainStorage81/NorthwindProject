using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ShipperManager : IShipperService
    {
        IShipperDal _shipperDal;

        public ShipperManager(IShipperDal shipperDal)
        {
            _shipperDal = shipperDal;
        }

        [ValidationAspect(typeof(ShipperValidator))]
        public IResult Add(Shipper shipper)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new ShipperValidator(), shipper));
            HandleException.ClassException(() => _shipperDal.Add(shipper));
            return new SuccessResult(ShipperMessages.Added);
        }

        [ValidationAspect(typeof(ShipperValidator))]
        public IResult AddAsync(Shipper shipper)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new ShipperValidator(), shipper));
            HandleException.ClassException(() => _shipperDal.AddAsync(shipper));
            return new SuccessResult(ShipperMessages.Added);
        }

        [ValidationAspect(typeof(ShipperValidator))]
        public IResult Update(Shipper shipper)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new ShipperValidator(), shipper));
            HandleException.ClassException(() => _shipperDal.Update(shipper));
            return new SuccessResult(ShipperMessages.Updated);
        }

        [ValidationAspect(typeof(ShipperValidator))]
        public IResult UpdateAsync(Shipper shipper)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new ShipperValidator(), shipper));
            HandleException.ClassException(() => _shipperDal.UpdateAsync(shipper));
            return new SuccessResult(ShipperMessages.Updated);
        }

        public IResult Delete(Shipper shipper)
        {
            HandleException.ClassException(() => _shipperDal.Delete(shipper));
            return new SuccessResult(ShipperMessages.Deleted);
        }

        public IResult DeleteAsync(Shipper shipper)
        {
            HandleException.ClassException(() => _shipperDal.DeleteAsync(shipper));
            return new SuccessResult(ShipperMessages.Deleted);
        }

        public IDataResult<Shipper> Get(Expression<Func<Shipper, bool>> filter)
        {
            var _get = _shipperDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Shipper>(ShipperMessages.RecordNotFound);
            }
            return new SuccessDataResult<Shipper>(_get, ShipperMessages.ShipperListed);
        }

        public IDataResult<Shipper> GetAsync(Expression<Func<Shipper, bool>> filter)
        {
            var _getAsync = _shipperDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Shipper>(ShipperMessages.RecordNotFound);
            }
            return new SuccessDataResult<Shipper>(_getAsync, ShipperMessages.ShipperListed);
        }

        public IDataResult<List<Shipper>> GetAll(Expression<Func<Shipper, bool>> filter = null)
        {
            var _getAll = _shipperDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Shipper>>(ShipperMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Shipper>>(_getAll, ShipperMessages.ShippersListed);
        }

        public IDataResult<List<Shipper>> GetAllAsync(Expression<Func<Shipper, bool>> filter = null)
        {
            var _getAllAsync = _shipperDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Shipper>>(ShipperMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Shipper>>(_getAllAsync, ShipperMessages.ShippersListed);
        }
    }
}
