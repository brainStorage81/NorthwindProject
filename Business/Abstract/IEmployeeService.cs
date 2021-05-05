using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IResult Add(Employee employee);
        IResult AddAsync(Employee employee);
        IResult TransactionalOperation(Employee employee);

        IResult Update(Employee employee);
        IResult UpdateAsync(Employee employee);

        IResult Delete(Employee employee);
        IResult DeleteAsync(Employee employee);

        IDataResult<Employee> Get(Expression<Func<Employee, bool>> filter);
        IDataResult<Employee> GetAsync(Expression<Func<Employee, bool>> filter);

        IDataResult<List<Employee>> GetAll(Expression<Func<Employee, bool>> filter = null);
        IDataResult<List<Employee>> GetAllAsync(Expression<Func<Employee, bool>> filter = null);

        IDataResult<List<EmployeeDto>> GetEmployeeDetails();
        IDataResult<List<EmployeeDto>> GetEmployeeDetailsAsync();

    }
}
