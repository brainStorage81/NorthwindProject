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
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("customer.add,admin")]
        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            
           _customerDal.Add(customer);
            return new SuccessResult(CustomerMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("customer.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult AddAsync(Customer customer)
        {            
            _customerDal.AddAsync(customer);
            return new SuccessResult(CustomerMessages.Added);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Customer customer)
        {
            
            Add(customer);
            if (customer.CompanyName.StartsWith("C"))
            {
                throw new Exception(CustomerMessages.CompanyNameInvalid);
            }
            return new SuccessResult(CustomerMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("customer.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {            
            _customerDal.Update(customer);
            return new SuccessResult(CustomerMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("customer.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult UpdateAsync(Customer customer)
        {            
            _customerDal.UpdateAsync(customer);
            return new SuccessResult(CustomerMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("customer.del,admin")]        
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(CustomerMessages.Deleted);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("customer.del,admin")]        
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult DeleteAsync(Customer customer)
        {
            _customerDal.DeleteAsync(customer);
            return new SuccessResult(CustomerMessages.Deleted);
        }

        [CacheAspect]
        [SecuredOperation("customer.list,admin")]
        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            var _get = _customerDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Customer>(CustomerMessages.RecordNotFound);
            }
            return new SuccessDataResult<Customer>(_get, CustomerMessages.CustomerListed);
        }

        [CacheAspect]
        [SecuredOperation("customer.list,admin")]
        public IDataResult<Customer> GetAsync(Expression<Func<Customer, bool>> filter)
        {
            var _getAsync = _customerDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Customer>(CustomerMessages.RecordNotFound);
            }
            return new SuccessDataResult<Customer>(_getAsync, CustomerMessages.CustomerListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("customer.list,admin")]
        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            var _getAll = _customerDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Customer>>(CustomerMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Customer>>(_getAll, CustomerMessages.CustomersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("customer.list,admin")]
        public IDataResult<List<Customer>> GetAllAsync(Expression<Func<Customer, bool>> filter = null)
        {
            var _getAllAsync = _customerDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Customer>>(CustomerMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Customer>>(_getAllAsync, CustomerMessages.CustomersListed);
        }
    }
}
