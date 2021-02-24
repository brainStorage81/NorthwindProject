using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new ProductValidator(), product));
            HandleException.ClassException(() => _productDal.Add(product));
            return new SuccessResult(ProductMessages.Added);

        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddAsync(Product product)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new ProductValidator(), product));
            HandleException.ClassException(() => _productDal.AddAsync(product));
            return new SuccessResult(ProductMessages.Added);

        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new ProductValidator(), product));
            HandleException.ClassException(() => _productDal.Update(product));
            return new Result(true, ProductMessages.Updated);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult UpdateAsync(Product product)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new ProductValidator(), product));
            HandleException.ClassException(() => _productDal.UpdateAsync(product));
            return new SuccessResult(ProductMessages.Updated);
        }

        public IResult Delete(Product product)
        {
            HandleException.ClassException(() => _productDal.Delete(product));
            return new Result(true, ProductMessages.Deleted);
        }
        
        public IResult DeleteAsync(Product product)
        {
            HandleException.ClassException(() => _productDal.DeleteAsync(product));
            return new SuccessResult(ProductMessages.Deleted);
        }

        public IDataResult<Product> GetById(int entity)
        {
            var _getById = _productDal.GetById(entity);

            if (_getById == null)
            {
                return new ErrorDataResult<Product>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<Product>(_getById, ProductMessages.ProductListed);
        }

        public IDataResult<Product> GetByIdAsync(int entity)
        {
            var _getByIdAsync = _productDal.GetByIdAsync(entity).Result;

            if (_getByIdAsync == null)
            {
                return new ErrorDataResult<Product>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<Product>(_getByIdAsync, ProductMessages.ProductListed);
        }

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

        public IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter)
        {
            var _getAll = _productDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Product>>(_getAll, ProductMessages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null)
        {
            var _getAllAsync = _productDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Product>>(_getAllAsync, ProductMessages.ProductsListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            var _getByUnitPrice = _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);

            if (_getByUnitPrice == null)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Product>>(_getByUnitPrice, ProductMessages.ProductListed);
        }

        public IDataResult<List<Product>> GetByUnitPriceAsync(decimal min, decimal max)
        {
            var _getByUnitPriceAsync = _productDal.GetAllAsync(p => p.UnitPrice >= min && p.UnitPrice <= max).Result;

            if (_getByUnitPriceAsync == null)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Product>>(_getByUnitPriceAsync, ProductMessages.ProductListed);
        }

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


    }
}
