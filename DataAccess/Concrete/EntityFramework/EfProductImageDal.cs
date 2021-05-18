using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfProductImageDal : EfEntityRepositoryBase<ProductImage, NorthwindContext>, IProductImageDal
	{
        public ProductImage GetById(int entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<ProductImage>().SingleOrDefault(p => p.Id == entity);
            }
        }

        public Task<ProductImage> GetByIdAsync(int entity)
        {
            NorthwindContext context = new NorthwindContext();
            {
                return context.Set<ProductImage>().SingleOrDefaultAsync(p => p.Id == entity);
            }
        }
    }
}
