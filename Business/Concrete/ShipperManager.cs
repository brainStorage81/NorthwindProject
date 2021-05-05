using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
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

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("shipper.add,admin")]
        [ValidationAspect(typeof(ShipperValidator), Priority = 1)]
        [CacheRemoveAspect("IShipperService.Get")]
        public IResult Add(Shipper shipper)
        {            
            _shipperDal.Add(shipper);
            return new SuccessResult(ShipperMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("shipper.add,admin")]
        [ValidationAspect(typeof(ShipperValidator))]
        [CacheRemoveAspect("IShipperService.Get")]
        public IResult AddAsync(Shipper shipper)
        {            
            _shipperDal.AddAsync(shipper);
            return new SuccessResult(ShipperMessages.Added);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Shipper shipper)
        {

            Add(shipper);
            if (shipper.ShipCompanyName.StartsWith("SHPC"))
            {
                throw new Exception(ShipperMessages.ShipperCompanyNameInvalid);
            }
            return new SuccessResult(ShipperMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("shipper.add,admin")]
        [ValidationAspect(typeof(ShipperValidator))]
        [CacheRemoveAspect("IShipperService.Get")]
        public IResult Update(Shipper shipper)
        {            
            _shipperDal.Update(shipper);
            return new SuccessResult(ShipperMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("shipper.add,admin")]
        [ValidationAspect(typeof(ShipperValidator))]
        [CacheRemoveAspect("IShipperService.Get")]
        public IResult UpdateAsync(Shipper shipper)
        {            
            _shipperDal.UpdateAsync(shipper);
            return new SuccessResult(ShipperMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("shipper.del,admin")]
        [CacheRemoveAspect("IShipperService.Get")]
        public IResult Delete(Shipper shipper)
        {
            _shipperDal.Delete(shipper);
            return new SuccessResult(ShipperMessages.Deleted);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("shipper.del,admin")]
        [CacheRemoveAspect("IShipperService.Get")]
        public IResult DeleteAsync(Shipper shipper)
        {
            _shipperDal.DeleteAsync(shipper);
            return new SuccessResult(ShipperMessages.Deleted);
        }

        [CacheAspect]
        [SecuredOperation("shipper.list,admin")]
        public IDataResult<Shipper> Get(Expression<Func<Shipper, bool>> filter)
        {
            var _get = _shipperDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Shipper>(ShipperMessages.RecordNotFound);
            }
            return new SuccessDataResult<Shipper>(_get, ShipperMessages.ShipperListed);
        }

        [CacheAspect]
        [SecuredOperation("shipper.list,admin")]
        public IDataResult<Shipper> GetAsync(Expression<Func<Shipper, bool>> filter)
        {
            var _getAsync = _shipperDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Shipper>(ShipperMessages.RecordNotFound);
            }
            return new SuccessDataResult<Shipper>(_getAsync, ShipperMessages.ShipperListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("shipper.list,admin")]
        public IDataResult<List<Shipper>> GetAll(Expression<Func<Shipper, bool>> filter = null)
        {
            var _getAll = _shipperDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Shipper>>(ShipperMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Shipper>>(_getAll, ShipperMessages.ShippersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("shipper.list,admin")]
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
