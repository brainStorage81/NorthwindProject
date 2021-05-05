using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult AddAsync(Customer customer);
        IResult TransactionalOperation(Customer customer);

        IResult Update(Customer customer);
        IResult UpdateAsync(Customer customer);

        IResult Delete(Customer customer);
        IResult DeleteAsync(Customer customer);

        IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter);
        IDataResult<Customer> GetAsync(Expression<Func<Customer, bool>> filter);

        IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null);
        IDataResult<List<Customer>> GetAllAsync(Expression<Func<Customer, bool>> filter = null);
    }
}
