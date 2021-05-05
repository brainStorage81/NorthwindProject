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
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("supplier.add,admin")]
        [ValidationAspect(typeof(SupplierValidator), Priority = 1)]
        [CacheRemoveAspect("ISupplierService.Get")]
        public IResult Add(Supplier supplier)
        {            
            _supplierDal.Add(supplier);
            return new SuccessResult(SupplierMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("supplier.add,admin")]
        [ValidationAspect(typeof(SupplierValidator))]
        [CacheRemoveAspect("ISupplierService.Get")]
        public IResult AddAsync(Supplier supplier)
        {            
            _supplierDal.AddAsync(supplier);
            return new SuccessResult(SupplierMessages.Added);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Supplier supplier)
        {

            Add(supplier);
            if (supplier.SupplierCompanyName.StartsWith("SHPC"))
            {
                throw new Exception(SupplierMessages.SupplierCompanyNameInvalid);
            }
            return new SuccessResult(SupplierMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("supplier.add,admin")]
        [ValidationAspect(typeof(SupplierValidator))]
        [CacheRemoveAspect("ISupplierService.Get")]
        public IResult Update(Supplier supplier)
        {            
            _supplierDal.Update(supplier);
            return new SuccessResult(SupplierMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("supplier.add,admin")]
        [ValidationAspect(typeof(SupplierValidator))]
        [CacheRemoveAspect("ISupplierService.Get")]
        public IResult UpdateAsync(Supplier supplier)
        {            
            _supplierDal.UpdateAsync(supplier);
            return new SuccessResult(SupplierMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("supplier.del,admin")]
        [CacheRemoveAspect("ISupplierService.Get")]
        public IResult Delete(Supplier supplier)
        {
            _supplierDal.Delete(supplier);
            return new SuccessResult(SupplierMessages.Deleted);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("supplier.del,admin")]
        [CacheRemoveAspect("ISupplierService.Get")]
        public IResult DeleteAsync(Supplier supplier)
        {
            _supplierDal.DeleteAsync(supplier);
            return new SuccessResult(SupplierMessages.Deleted);
        }

        [CacheAspect]
        [SecuredOperation("supplier.list,admin")]
        public IDataResult<Supplier> Get(Expression<Func<Supplier, bool>> filter)
        {
            var _get = _supplierDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Supplier>(SupplierMessages.RecordNotFound);
            }

            return new SuccessDataResult<Supplier>(_get, SupplierMessages.SupplierListed);
        }

        [CacheAspect]
        [SecuredOperation("supplier.list,admin")]
        public IDataResult<Supplier> GetAsync(Expression<Func<Supplier, bool>> filter)
        {
            var _getAsync = _supplierDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Supplier>(SupplierMessages.RecordNotFound);
            }
            return new SuccessDataResult<Supplier>(_getAsync, SupplierMessages.SupplierListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("supplier.list,admin")]
        public IDataResult<List<Supplier>> GetAll(Expression<Func<Supplier, bool>> filter = null)
        {
            var _getAll = _supplierDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Supplier>>(SupplierMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Supplier>>(_getAll, SupplierMessages.SuppliersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("supplier.list,admin")]
        public IDataResult<List<Supplier>> GetAllAsync(Expression<Func<Supplier, bool>> filter = null)
        {
            var _getAllAsync = _supplierDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Supplier>>(SupplierMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Supplier>>(_getAllAsync, SupplierMessages.SuppliersListed);
        }
    }
}
