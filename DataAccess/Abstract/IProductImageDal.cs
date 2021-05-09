using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IProductImageDal : IEntityRepository<ProductImage>, IAsyncEntityRepository<ProductImage>
	{
		ProductImage GetById(int entity);
		Task<ProductImage> GetByIdAsync(int entity);
	}
}
