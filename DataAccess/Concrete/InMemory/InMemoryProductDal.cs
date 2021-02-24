using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        List<Category> _category;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1,ProductName="Çay Bardağı", UnitPrice=15, UnitsInStock=15, QuantityPerUnit="1 kutuda 6 adet bulunmaktadır."},
                new Product{ProductId=2, CategoryId=2,ProductName="Canon Kamera", UnitPrice=500, UnitsInStock=3, QuantityPerUnit="1 kutuda 3 adet bulunmaktadır."},
                new Product{ProductId=3, CategoryId=3,ProductName="Samsung Telefon", UnitPrice=1500, UnitsInStock=2, QuantityPerUnit="1 kutuda 6 adet bulunmaktadır."},
                new Product{ProductId=4, CategoryId=2,ProductName="A4 Klavye", UnitPrice=150, UnitsInStock=65, QuantityPerUnit="1 kutuda 12 adet bulunmaktadır."},
                new Product{ProductId=5, CategoryId=2,ProductName="Logitech Mouse", UnitPrice=85, UnitsInStock=1, QuantityPerUnit="1 kutuda 6 adet bulunmaktadır."}

            };

            _category = new List<Category>
            {
                new Category{CategoryId=1,CategoryName="Mutfak Ürünleri", CategoryDescription="Mutfakta kullanılan ürünler."},
                new Category{CategoryId=2,CategoryName="Bilgisayar Ürünleri", CategoryDescription="Bilgisayar ile ilgili ürünler." },
                new Category{CategoryId=3,CategoryName="Telefon Ürünleri", CategoryDescription="Telefon ile ilgili ürünler." }

            };

        }

        public void Add(Product entity)
        {
            _products.Add(entity);
        }

        public void Delete(Product entity)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == entity.ProductId);

            _products.Remove(productToDelete);
        }

        public void Update(Product entity)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == entity.ProductId);
            productToUpdate.ProductName = entity.ProductName;
            productToUpdate.CategoryId = entity.CategoryId;
            productToUpdate.UnitPrice = entity.UnitPrice;
            productToUpdate.UnitsInStock = entity.UnitsInStock;
            productToUpdate.QuantityPerUnit = entity.QuantityPerUnit;

        }
        
        public List<ProductDto> GetAllByProductNameOrCategoryNameWhereConstain(string constain)
        {
            var result = from p in _products
                         join c in _category
                         on p.CategoryId equals c.CategoryId
                         where p.ProductName.Contains(constain) | c.CategoryName.Contains(constain)

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

        public List<Product> GetAllByProductNameWhereConstain(string entity)
        {
            return _products.Where(p => p.ProductName.Contains(entity)).ToList();
        }

        public List<ProductDto> GetProductDetails()
        {
            var result = from p in _products
                         join c in _category
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

        public Product GetById(int entity)
        {
            return _products.SingleOrDefault(p => p.ProductId == entity);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        //Async Blok
        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }
        public Task<Product> GetAsync(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductDetailsAsync()
        {
            var result = from p in _products
                         join c in _category
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
            return (Task<List<ProductDto>>)result;
        }
        public Task<List<ProductDto>> GetAllByProductNameOrCategoryNameWhereConstainAsync(string constain)
        {
            var result = from p in _products
                         join c in _category
                         on p.CategoryId equals c.CategoryId
                         where p.ProductName.Contains(constain) | c.CategoryName.Contains(constain)

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

            return (Task<List<ProductDto>>)result;
        }

        public Task<List<Product>> GetAllByProductNameWhereConstainAsync(string entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int entity)
        {
            throw new NotImplementedException();
        }
    }
}
