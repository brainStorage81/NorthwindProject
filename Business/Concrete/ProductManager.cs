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
using Core.Utilities.Exceptions;
using Core.Utilities.ForBusiness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator),Priority=1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExists(product.ProductName), CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(ProductMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult AddAsync(Product product)
        {
            _productDal.AddAsync(product);
            return new SuccessResult(ProductMessages.Added);

        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            
            Add(product);
            if (product.UnitPrice <= 10)
            {
                throw new Exception(ProductMessages.ProductPriceCannotBeLessThan);
            }
            return new SuccessResult(ProductMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new Result(true, ProductMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult UpdateAsync(Product product)
        {
            _productDal.UpdateAsync(product);
            return new SuccessResult(ProductMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("product.del,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new Result(true, ProductMessages.Deleted);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("product.del,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult DeleteAsync(Product product)
        {
            _productDal.DeleteAsync(product);
            return new SuccessResult(ProductMessages.Deleted);
        }

        [CacheAspect]
        [SecuredOperation("product.list,admin")]
        public IDataResult<Product> GetById(int entity)
        {
            var _getById = _productDal.GetById(entity);

            if (_getById == null)
            {
                return new ErrorDataResult<Product>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<Product>(_getById, ProductMessages.ProductListed);
        }

        [CacheAspect]
        [SecuredOperation("product.list,admin")]
        public IDataResult<Product> GetByIdAsync(int entity)
        {
            var _getByIdAsync = _productDal.GetByIdAsync(entity).Result;

            if (_getByIdAsync == null)
            {
                return new ErrorDataResult<Product>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<Product>(_getByIdAsync, ProductMessages.ProductListed);
        }

        [CacheAspect]
        [SecuredOperation("product.list,admin")]
        public IDataResult<Product> Get(Expression<Func<Product, bool>> filter)
        {
            if (DateTime.Now.Hour == 07)
            {
                return new ErrorDataResult<Product>(ProductMessages.MaintenanceTime);
            }

            var _get = _productDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Product>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<Product>(_get, ProductMessages.ProductListed);
        }

        [CacheAspect]
        [SecuredOperation("product.list,admin")]
        public IDataResult<Product> GetAsync(Expression<Func<Product, bool>> filter)
        {
            if (DateTime.Now.Hour == 07)
            {
                return new ErrorDataResult<Product>(ProductMessages.MaintenanceTime);
            }

            var _getAsync = _productDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Product>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<Product>(_getAsync, ProductMessages.ProductListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("product.list,admin")]
        public IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter)
        {
            var _getAll = _productDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Product>>(_getAll, ProductMessages.ProductsListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("product.list,admin")]
        public IDataResult<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null)
        {
            var _getAllAsync = _productDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Product>>(_getAllAsync, ProductMessages.ProductsListed);
        }

        [CacheAspect]
        [SecuredOperation("product.list,admin")]
        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            var _getByUnitPrice = _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);

            if (_getByUnitPrice == null)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Product>>(_getByUnitPrice, ProductMessages.ProductListed);
        }

        [CacheAspect]
        [SecuredOperation("product.list,admin")]
        public IDataResult<List<Product>> GetByUnitPriceAsync(decimal min, decimal max)
        {
            var _getByUnitPriceAsync = _productDal.GetAllAsync(p => p.UnitPrice >= min && p.UnitPrice <= max).Result;

            if (_getByUnitPriceAsync == null)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Product>>(_getByUnitPriceAsync, ProductMessages.ProductListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("product.list,admin")]
        public IDataResult<List<ProductDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 07)
            {
                return new ErrorDataResult<List<ProductDto>>(ProductMessages.MaintenanceTime);
            }

            var _getProductDetails = _productDal.GetProductDetails();

            if (_getProductDetails == null)
            {
                return new ErrorDataResult<List<ProductDto>>(ProductMessages.RecordNotFound);
            }

            return new SuccessDataResult<List<ProductDto>>(_getProductDetails, ProductMessages.ProductDetailsListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("product.list,admin")]
        public IDataResult<List<ProductDto>> GetProductDetailsAsync()
        {
            if (DateTime.Now.Hour == 07)
            {
                return new ErrorDataResult<List<ProductDto>>(ProductMessages.MaintenanceTime);
            }

            var _getProductDetailsAsync = _productDal.GetProductDetailsAsync().Result;

            if (_getProductDetailsAsync == null)
            {
                return new ErrorDataResult<List<ProductDto>>(ProductMessages.RecordNotFound);
            }

            return new SuccessDataResult<List<ProductDto>>(_getProductDetailsAsync, ProductMessages.ProductDetailsListed);
        }

        [CacheAspect]
        [SecuredOperation("product.list,admin")]
        public IDataResult<List<Product>> GetAllByCategoryId(int entity)
        {
            var _getAllByCategoryId = _productDal.GetAll((p => p.CategoryId == entity)).ToList();

            if (_getAllByCategoryId == null)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Product>>(_getAllByCategoryId, ProductMessages.ProductsListed);
        }

        [CacheAspect]
        [SecuredOperation("product.list,admin")]
        public IDataResult<List<Product>> GetAllByCategoryIdAsync(int entity)
        {
            var _getAllByCategoryIdAsync = _productDal.GetAllAsync((p => p.CategoryId == entity)).Result.ToList();

            if (_getAllByCategoryIdAsync == null)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Product>>(_getAllByCategoryIdAsync, ProductMessages.ProductsListed);
        }

        //internal operations
        private IResult CheckIfProductCountOfCategoryCorrect(int entity)
        {
            //Select Count(*) from Products p where p.CategoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == entity).Count;
            if (result >= 15)
            {
                return new ErrorResult(ProductMessages.CategoryLimitValueCannotBeExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(ProductMessages.ProductNameAlreadyExists);
            }
            return new SuccessResult();

        }

        private IResult CheckIfCategoryLimitExceded()
        {

            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(ProductMessages.CategoryLimitValueExceeded);
            }
            return new SuccessResult();
        }
    }
}
