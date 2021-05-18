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
    public interface IProductService
    {
        IResult Add(Product product);
        IResult AddAsync(Product product);
        IResult TransactionalOperation(Product product);

        IResult Update(Product product);
        IResult UpdateAsync(Product product);

        IResult Delete(Product product);
        IResult DeleteAsync(Product product);

        IDataResult<Product> GetById(int entity);
        IDataResult<Product> GetByIdAsync(int entity);

        IDataResult<Product> Get(Expression<Func<Product, bool>> filter);
        IDataResult<Product> GetAsync(Expression<Func<Product, bool>> filter);

        IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null);
        IDataResult<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null);

        IDataResult<List<Product>> GetAllByCategoryId(int entity);
        IDataResult<List<Product>> GetAllByCategoryIdAsync(int entity);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<Product>> GetByUnitPriceAsync(decimal min, decimal max);

        IDataResult<List<ProductDto>> GetProductDetails();
        IDataResult<List<ProductDto>> GetProductDetailsAsync();
       
    }
}
