using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDto> GetAllByProductNameOrCategoryNameWhereConstain(string constain)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             where p.ProductName.Contains(constain) | c.CategoryName.Contains(constain)
                             
                             select new ProductDto 
                             { 
                                 ProductId = p.ProductId, 
                                 CategoryName = c.CategoryName, 
                                 CategoryDescription=c.CategoryDescription, 
                                 ProductName = p.ProductName, 
                                 QuantityPerUnit=p.QuantityPerUnit, 
                                 UnitPrice = p.UnitPrice, 
                                 UnitsInStock = p.UnitsInStock
                             };

                return result.ToList();
            }
        }

        public Task<List<ProductDto>> GetAllByProductNameOrCategoryNameWhereConstainAsync(string constain)
        {
            NorthwindContext context = new NorthwindContext();
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             where p.ProductName.Contains(constain) | c.CategoryName.Contains(constain)
                             
                             select new ProductDto   
                             { 
                                 ProductId = p.ProductId, 
                                 CategoryName = c.CategoryName, 
                                 CategoryDescription=c.CategoryDescription, 
                                 ProductName = p.ProductName, 
                                 QuantityPerUnit=p.QuantityPerUnit, 
                                 UnitPrice = p.UnitPrice, 
                                 UnitsInStock = p.UnitsInStock
                             };

                return result.ToListAsync();
            }
        }

        public List<Product> GetAllByProductNameWhereConstain(string entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.Where(p => p.ProductName.Contains(entity)).ToList();
            }
        }

        public Task<List<Product>> GetAllByProductNameWhereConstainAsync(string entity)
        {
            NorthwindContext context = new NorthwindContext();

            return context.Products.Where(p => p.ProductName.Contains(entity)).ToListAsync();
        }

        public Product GetById(int entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(p => p.ProductId == entity);
            }
        }

        public Task<Product> GetByIdAsync(int entity)
        {
            NorthwindContext context = new NorthwindContext();
            {
                return context.Set<Product>().SingleOrDefaultAsync(p => p.ProductId == entity);
            }
        }

        public List<ProductDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId

                             select new ProductDto
                             {
                                 ProductId = p.ProductId,
                                 CategoryName = c.CategoryName,
                                 CategoryDescription = c.CategoryDescription,
                                 ProductName = p.ProductName,
                                 QuantityPerUnit = p.QuantityPerUnit,
                                 UnitPrice = p.UnitPrice,
                                 UnitsInStock = p.UnitsInStock
                             };

                return result.ToList();
            }
        }
        public Task<List<ProductDto>> GetProductDetailsAsync()
        {
            NorthwindContext context = new NorthwindContext();

            var result = from p in context.Products
                         join c in context.Categories
                         on p.CategoryId equals c.CategoryId

                         select new ProductDto
                         {
                             ProductId = p.ProductId,
                             CategoryName = c.CategoryName,
                             CategoryDescription = c.CategoryDescription,
                             ProductName = p.ProductName,
                             QuantityPerUnit = p.QuantityPerUnit,
                             UnitPrice = p.UnitPrice,
                             UnitsInStock = p.UnitsInStock
                         };

            return result.ToListAsync();
        }
    }
}
