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
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        [ValidationAspect(typeof(SupplierValidator))]
        public IResult Add(Supplier supplier)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new SupplierValidator(), supplier));
            HandleException.ClassException(() => _supplierDal.Add(supplier));
            return new SuccessResult(SupplierMessages.Added);
        }

        [ValidationAspect(typeof(SupplierValidator))]
        public IResult AddAsync(Supplier supplier)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new SupplierValidator(), supplier));
            HandleException.ClassException(() => _supplierDal.AddAsync(supplier));
            return new SuccessResult(SupplierMessages.Added);
        }

        [ValidationAspect(typeof(SupplierValidator))]
        public IResult Update(Supplier supplier)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new SupplierValidator(), supplier));
            HandleException.ClassException(() => _supplierDal.Update(supplier));
            return new SuccessResult(SupplierMessages.Updated);
        }

        [ValidationAspect(typeof(SupplierValidator))]
        public IResult UpdateAsync(Supplier supplier)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new SupplierValidator(), supplier));
            HandleException.ClassException(() => _supplierDal.UpdateAsync(supplier));
            return new SuccessResult(SupplierMessages.Updated);
        }

        public IResult Delete(Supplier supplier)
        {
            HandleException.ClassException(() => _supplierDal.Delete(supplier));
            return new SuccessResult(SupplierMessages.Deleted);
        }

        public IResult DeleteAsync(Supplier supplier)
        {
            HandleException.ClassException(() => _supplierDal.DeleteAsync(supplier));
            return new SuccessResult(SupplierMessages.Deleted);
        }

        public IDataResult<Supplier> Get(Expression<Func<Supplier, bool>> filter)
        {
            var _get = _supplierDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Supplier>(SupplierMessages.RecordNotFound);
            }

            return new SuccessDataResult<Supplier>(_get, SupplierMessages.SupplierListed);
        }

        public IDataResult<Supplier> GetAsync(Expression<Func<Supplier, bool>> filter)
        {
            var _getAsync = _supplierDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Supplier>(SupplierMessages.RecordNotFound);
            }
            return new SuccessDataResult<Supplier>(_getAsync, SupplierMessages.SupplierListed);
        }

        public IDataResult<List<Supplier>> GetAll(Expression<Func<Supplier, bool>> filter = null)
        {
            var _getAll = _supplierDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Supplier>>(SupplierMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Supplier>>(_getAll, SupplierMessages.SuppliersListed);
        }

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
