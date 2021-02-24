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

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new CustomerValidator(), customer));
            HandleException.ClassException(() => _customerDal.Add(customer));
            return new SuccessResult(CustomerMessages.Added);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult AddAsync(Customer customer)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new CustomerValidator(), customer));
            HandleException.ClassException(() => _customerDal.AddAsync(customer));
            return new SuccessResult(CustomerMessages.Added);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new CustomerValidator(), customer));
            HandleException.ClassException(() => _customerDal.Update(customer));
            return new SuccessResult(CustomerMessages.Updated);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult UpdateAsync(Customer customer)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new CustomerValidator(), customer));
            HandleException.ClassException(() => _customerDal.UpdateAsync(customer));
            return new SuccessResult(CustomerMessages.Updated);
        }

        public IResult Delete(Customer customer)
        {
            HandleException.ClassException(() => _customerDal.Delete(customer));
            return new SuccessResult(CustomerMessages.Deleted);
        }

        public IResult DeleteAsync(Customer customer)
        {
            HandleException.ClassException(() => _customerDal.DeleteAsync(customer));
            return new SuccessResult(CustomerMessages.Deleted);
        }

        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            var _get = _customerDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Customer>(CustomerMessages.RecordNotFound);
            }
            return new SuccessDataResult<Customer>(_get, CustomerMessages.CustomerListed);
        }

        public IDataResult<Customer> GetAsync(Expression<Func<Customer, bool>> filter)
        {
            var _getAsync = _customerDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Customer>(CustomerMessages.RecordNotFound);
            }
            return new SuccessDataResult<Customer>(_getAsync, CustomerMessages.CustomerListed);
        }

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            var _getAll = _customerDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Customer>>(CustomerMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Customer>>(_getAll, CustomerMessages.CustomersListed);
        }

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
