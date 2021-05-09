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
using Core.Utilities.ForBusiness;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
	public class ProductImageManager : IProductImageService
	{
		IProductImageDal _productImageDal;

		public ProductImageManager(IProductImageDal productImageDal)
		{
			_productImageDal = productImageDal;
		}

		[LogAspect(typeof(FileLogger))]
		[SecuredOperation("productimage.add,admin")]
		[ValidationAspect(typeof(ProductImageValidator), Priority = 1)]
		[CacheRemoveAspect("IProductImageService.Get")]
		public IResult Add(IFormFile file, ProductImage productImage)
		{
			IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.Id), CheckIfProductImageNull(productImage.ProductId));
			if (result != null)
			{
				return result;
			}

			productImage.ImagePath = FileHelper.Add(file);
			productImage.ImageName = Path.GetFileName(productImage.ImagePath);
			productImage.Date = DateTime.Now;
			_productImageDal.Add(productImage);
			return new SuccessResult(ProductImagesMessages.Added);
		}

		[LogAspect(typeof(FileLogger))]
		[SecuredOperation("productimage.add,admin")]
		[ValidationAspect(typeof(ProductImageValidator))]
		[CacheRemoveAspect("IProductImageService.Get")]
		public IResult AddAsync(IFormFile file, ProductImage productImage)
		{
			productImage.ImagePath = FileHelper.Add(file);
			productImage.ImageName = Path.GetFileName(productImage.ImagePath);
			productImage.Date = DateTime.Now;
			_productImageDal.AddAsync(productImage);
			return new SuccessResult(ProductImagesMessages.Added);
		}

		[TransactionScopeAspect]
		public IResult TransactionalOperation(IFormFile file, ProductImage productImage)
		{
			Add(file, productImage);
			if (productImage.ImageName.Length==0)
			{
				throw new Exception(ProductImagesMessages.ProductImageNameCannotBeEmpty);
			}
			return new SuccessResult(ProductImagesMessages.Added);
		}

		[LogAspect(typeof(FileLogger))]
		[SecuredOperation("productimage.add,admin")]
		[ValidationAspect(typeof(ProductImageValidator))]
		[CacheRemoveAspect("IProductImageService.Get")]
		public IResult Update(IFormFile file, ProductImage productImage)
		{
			IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.Id));
			if (result != null)
			{
				return result;
			}
			productImage.ImagePath = FileHelper.Update(_productImageDal.Get(p => p.Id == productImage.Id).ImagePath, file);
			productImage.Date = DateTime.Now;
			_productImageDal.Update(productImage);
			return new SuccessResult(ProductImagesMessages.Updated);
		}

		[LogAspect(typeof(FileLogger))]
		[SecuredOperation("productimage.add,admin")]
		[ValidationAspect(typeof(ProductImageValidator))]
		[CacheRemoveAspect("IProductImageService.Get")]
		public IResult UpdateAsync(IFormFile file, ProductImage productImage)
		{
			productImage.ImagePath = FileHelper.Update(_productImageDal.Get(p => p.Id == productImage.Id).ImagePath, file);
			productImage.Date = DateTime.Now;
			_productImageDal.UpdateAsync(productImage);
			return new SuccessResult(ProductImagesMessages.Updated);
		}

		[LogAspect(typeof(FileLogger))]
		[SecuredOperation("productimage.del,admin")]
		[CacheRemoveAspect("IProductImageService.Get")]
		public IResult Delete(ProductImage productImage)
		{
			FileHelper.Delete(productImage.ImagePath);
			_productImageDal.Delete(productImage);
			return new SuccessResult(ProductImagesMessages.Deleted);
		}

		[LogAspect(typeof(FileLogger))]
		[SecuredOperation("productimage.del,admin")]
		[CacheRemoveAspect("IProductImageService.Get")]
		public IResult DeleteAsync(ProductImage productImage)
		{
			FileHelper.Delete(productImage.ImagePath);
			_productImageDal.DeleteAsync(productImage);
			return new SuccessResult(ProductImagesMessages.Deleted);
		}

		[CacheAspect]
		[SecuredOperation("productimage.list,admin")]
		public IDataResult<ProductImage> GetById(int entity)
		{
			var _getById = _productImageDal.GetById(entity);

			if (_getById == null)
			{
				return new ErrorDataResult<ProductImage>(ProductImagesMessages.RecordNotFound);
			}
			return new SuccessDataResult<ProductImage>(_getById, ProductImagesMessages.ProductImageListed);
		}

		[CacheAspect]
		[SecuredOperation("productimage.list,admin")]
		public IDataResult<ProductImage> GetByIdAsync(int entity)
		{
			var _getByIdAsync = _productImageDal.GetByIdAsync(entity).Result;

			if (_getByIdAsync == null)
			{
				return new ErrorDataResult<ProductImage>(ProductImagesMessages.RecordNotFound);
			}
			return new SuccessDataResult<ProductImage>(_getByIdAsync, ProductImagesMessages.ProductImageListed);
		}

		[CacheAspect]
		[SecuredOperation("productimage.list,admin")]
		public IDataResult<ProductImage> Get(Expression<Func<ProductImage, bool>> filter)
		{
			if (DateTime.Now.Hour == 07)
			{
				return new ErrorDataResult<ProductImage>(ProductImagesMessages.MaintenanceTime);
			}

			var _get = _productImageDal.Get(filter);

			if (_get == null)
			{
				return new ErrorDataResult<ProductImage>(ProductImagesMessages.RecordNotFound);
			}
			return new SuccessDataResult<ProductImage>(_get, ProductImagesMessages.ProductImageListed);
		}

		[CacheAspect]
		[SecuredOperation("productimage.list,admin")]
		public IDataResult<ProductImage> GetAsync(Expression<Func<ProductImage, bool>> filter)
		{
			if (DateTime.Now.Hour == 07)
			{
				return new ErrorDataResult<ProductImage>(ProductImagesMessages.MaintenanceTime);
			}

			var _getAsync = _productImageDal.GetAsync(filter).Result;

			if (_getAsync == null)
			{
				return new ErrorDataResult<ProductImage>(ProductImagesMessages.RecordNotFound);
			}
			return new SuccessDataResult<ProductImage>(_getAsync, ProductImagesMessages.ProductImageListed);
		}

		[PerformanceAspect(5)]
		[CacheAspect(duration: 10)]
		[SecuredOperation("productimage.list,admin")]
		public IDataResult<List<ProductImage>> GetAll(Expression<Func<ProductImage, bool>> filter = null)
		{
			var _getAll = _productImageDal.GetAll(filter);

			if (_getAll == null)
			{
				return new ErrorDataResult<List<ProductImage>>(ProductImagesMessages.RecordNotFound);
			}
			return new SuccessDataResult<List<ProductImage>>(_getAll, ProductImagesMessages.ProductImagesListed);
		}

		[PerformanceAspect(5)]
		[CacheAspect(duration: 10)]
		[SecuredOperation("productimage.list,admin")]
		public IDataResult<List<ProductImage>> GetAllAsync(Expression<Func<ProductImage, bool>> filter = null)
		{
			var _getAllAsync = _productImageDal.GetAllAsync(filter).Result;

			if (_getAllAsync == null)
			{
				return new ErrorDataResult<List<ProductImage>>(ProductImagesMessages.RecordNotFound);
			}
			return new SuccessDataResult<List<ProductImage>>(_getAllAsync, ProductImagesMessages.ProductImagesListed);
		}

		[PerformanceAspect(5)]
		[CacheAspect(duration: 10)]
		[SecuredOperation("productimage.list,admin")]
		public IDataResult<List<ProductImage>> GetAllByProductId(int entity)
		{
			var _getAllByProductId = _productImageDal.GetAll((p => p.ProductId == entity)).ToList();

			if (_getAllByProductId == null)
			{
				return new ErrorDataResult<List<ProductImage>>(ProductImagesMessages.RecordNotFound);
			}
			return new SuccessDataResult<List<ProductImage>>(_getAllByProductId, ProductImagesMessages.ProductImagesListed);
		}

		[PerformanceAspect(5)]
		[CacheAspect(duration: 10)]
		[SecuredOperation("productimage.list,admin")]
		public IDataResult<List<ProductImage>> GetAllByProductIdAsync(int entity)
		{
			var _getAllByProductIdAsync = _productImageDal.GetAllAsync((p => p.ProductId == entity)).Result.ToList();

			if (_getAllByProductIdAsync == null)
			{
				return new ErrorDataResult<List<ProductImage>>(ProductImagesMessages.RecordNotFound);
			}
			return new SuccessDataResult<List<ProductImage>>(_getAllByProductIdAsync, ProductImagesMessages.ProductImagesListed);
		}


		
		
		//business rules
		private IResult CheckImageLimitExceeded(int productId)
		{
			var productImagecount = _productImageDal.GetAll(p => p.ProductId == productId).Count;
			if (productImagecount >= 5)
			{
				return new ErrorResult(ProductImagesMessages.ProductImageLimitValueExceeded);
			}

			return new SuccessResult();
		}	

		private IDataResult<ProductImage> CheckIfProductImageNull(int productId)
		{
			try
			{
				string path = @"\wwwroot\Images\logo.jpg";
				var result = _productImageDal.Get(p => p.ProductId == productId);
				if (result==null)
				{
					_productImageDal.Add(new ProductImage { ProductId = productId, ImagePath = path, Date = DateTime.Now });
					var result2 = _productImageDal.Get(p => p.ProductId == productId);
					return new SuccessDataResult<ProductImage>(result2);
				}
			}
			catch (Exception exception)
			{

				return new ErrorDataResult<ProductImage>(exception.Message);
			}

			return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.ProductId == productId));
		} 
    }
}
