using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Exceptions;
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

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Add(Employee employee)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new EmployeeValidator(), employee));
            HandleException.ClassException(() => _employeeDal.Add(employee));
            return new SuccessResult(EmployeeMessages.Added);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult AddAsync(Employee employee)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new EmployeeValidator(), employee));
            HandleException.ClassException(() => _employeeDal.AddAsync(employee));
            return new SuccessResult(EmployeeMessages.Added);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Update(Employee employee)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new EmployeeValidator(), employee));
            HandleException.ClassException(() => _employeeDal.Update(employee));
            return new SuccessResult(EmployeeMessages.Updated);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult UpdateAsync(Employee employee)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new EmployeeValidator(), employee));
            HandleException.ClassException(() => _employeeDal.UpdateAsync(employee));
            return new SuccessResult(EmployeeMessages.Updated);
        }

        public IResult Delete(Employee employee)
        {
            HandleException.ClassException(() => _employeeDal.Delete(employee));
            return new SuccessResult(EmployeeMessages.Deleted);
        }

        public IResult DeleteAsync(Employee employee)
        {
            HandleException.ClassException(() => _employeeDal.DeleteAsync(employee));
            return new SuccessResult(EmployeeMessages.Deleted);
        }

        public IDataResult<Employee> Get(Expression<Func<Employee, bool>> filter)
        {
            var _get = _employeeDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Employee>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<Employee>(_get, EmployeeMessages.EmployeeListed);
        }

        public IDataResult<Employee> GetAsync(Expression<Func<Employee, bool>> filter)
        {
            var _getAsync = _employeeDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Employee>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<Employee>(_getAsync, EmployeeMessages.EmployeeListed);
        }

        public IDataResult<List<Employee>> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            var _getAll = _employeeDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Employee>>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Employee>>(_getAll, EmployeeMessages.EmployeesListed);
        }

        public IDataResult<List<Employee>> GetAllAsync(Expression<Func<Employee, bool>> filter = null)
        {
            var _getAllAsync = _employeeDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Employee>>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Employee>>(_getAllAsync, EmployeeMessages.EmployeesListed);
        }

        public IDataResult<List<EmployeeDto>> GetEmployeeDetails()
        {
            var _getEmployeeDetails = _employeeDal.GetEmployeeDetails();

            if (_getEmployeeDetails == null)
            {
                return new ErrorDataResult<List<EmployeeDto>>(EmployeeMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<EmployeeDto>>(_getEmployeeDetails, EmployeeMessages.EmployeeDetailsListed);
        }

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
