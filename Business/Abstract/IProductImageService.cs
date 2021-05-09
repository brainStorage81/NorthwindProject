using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
	public interface IProductImageService
	{
		IResult Add(IFormFile file, ProductImage productImage);
		IResult AddAsync(IFormFile file, ProductImage productImage);
		IResult TransactionalOperation(IFormFile file, ProductImage productImage);

		IResult Update(IFormFile file, ProductImage productImage);
		IResult UpdateAsync(IFormFile file, ProductImage productImage);

		IResult Delete(ProductImage productImage);
		IResult DeleteAsync(ProductImage productImage);

		IDataResult<ProductImage> GetById(int entity);
		IDataResult<ProductImage> GetByIdAsync(int entity);

		IDataResult<ProductImage> Get(Expression<Func<ProductImage, bool>> filter);
		IDataResult<ProductImage> GetAsync(Expression<Func<ProductImage, bool>> filter);
		
		IDataResult<List<ProductImage>> GetAll(Expression<Func<ProductImage, bool>> filter = null);
		IDataResult<List<ProductImage>> GetAllAsync(Expression<Func<ProductImage, bool>> filter = null);

		IDataResult<List<ProductImage>> GetAllByProductId(int entity);
		IDataResult<List<ProductImage>> GetAllByProductIdAsync(int entity);

	}
}
