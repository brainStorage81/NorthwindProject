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
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("employee.add,admin")]
        [ValidationAspect(typeof(EmployeeValidator), Priority = 1)]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Add(Employee employee)
        {
            
            _employeeDal.Add(employee);
            return new SuccessResult(EmployeeMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("employee.add,admin")]
        [ValidationAspect(typeof(EmployeeValidator))]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult AddAsync(Employee employee)
        {            
            _employeeDal.AddAsync(employee);
            return new SuccessResult(EmployeeMessages.Added);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Employee employee)
        {
            
            Add(employee);
            if (employee.EmployeeFirsName.StartsWith("E"))
            {
                throw new Exception(EmployeeMessages.FirstNameInvalid);
            }
            return new SuccessResult(EmployeeMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("employee.add,admin")]
        [ValidationAspect(typeof(EmployeeValidator))]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Update(Employee employee)
        {           
            _employeeDal.Update(employee);
            return new SuccessResult(EmployeeMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("employee.add,admin")]
        [ValidationAspect(typeof(EmployeeValidator))]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult UpdateAsync(Employee employee)
        {            
            _employeeDal.UpdateAsync(employee);
            return new SuccessResult(EmployeeMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("employee.del,admin")]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult(EmployeeMessages.Deleted);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("employee.del,admin")]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult DeleteAsync(Employee employee)
        {
            _employeeDal.DeleteAsync(employee);
            return new SuccessResult(EmployeeMessages.Deleted);
        }

        [CacheAspect]
        [SecuredOperation("employee.list,admin")]
        public IDataResult<Employee> Get(Expression<Func<Employee, bool>> filter)
        {
            var _get = _employeeDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Employee>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<Employee>(_get, EmployeeMessages.EmployeeListed);
        }

        [CacheAspect]
        [SecuredOperation("employee.list,admin")]
        public IDataResult<Employee> GetAsync(Expression<Func<Employee, bool>> filter)
        {
            var _getAsync = _employeeDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Employee>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<Employee>(_getAsync, EmployeeMessages.EmployeeListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("employee.list,admin")]
        public IDataResult<List<Employee>> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            var _getAll = _employeeDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Employee>>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Employee>>(_getAll, EmployeeMessages.EmployeesListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("employee.list,admin")]
        public IDataResult<List<Employee>> GetAllAsync(Expression<Func<Employee, bool>> filter = null)
        {
            var _getAllAsync = _employeeDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Employee>>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Employee>>(_getAllAsync, EmployeeMessages.EmployeesListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("employee.list,admin")]
        public IDataResult<List<EmployeeDto>> GetEmployeeDetails()
        {
            var _getEmployeeDetails = _employeeDal.GetEmployeeDetails();

            if (_getEmployeeDetails == null)
            {
                return new ErrorDataResult<List<EmployeeDto>>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<EmployeeDto>>(_getEmployeeDetails, EmployeeMessages.EmployeeDetailsListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("employee.list,admin")]
        public IDataResult<List<EmployeeDto>> GetEmployeeDetailsAsync()
        {
            var _getEmployeeDetailsAsync = _employeeDal.GetEmployeeDetailsAsync().Result;

            if (_getEmployeeDetailsAsync == null)
            {
                return new ErrorDataResult<List<EmployeeDto>>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<EmployeeDto>>(_getEmployeeDetailsAsync, EmployeeMessages.EmployeeDetailsListed);
        }
    }
}
