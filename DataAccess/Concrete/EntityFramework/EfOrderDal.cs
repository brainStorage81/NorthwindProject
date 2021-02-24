using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderDal
    {
        public List<Order> GetAllByShipCityWhereConstain(string entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Orders.Where(p => p.ShipCity.Contains(entity)).ToList();
            }
        }

        public Task<List<Order>> GetAllByShipCityWhereConstainAsync(string entity)
        {
            NorthwindContext context = new NorthwindContext();

            return context.Orders.Where(p => p.ShipCity.Contains(entity)).ToListAsync();
        }

        public List<OrderDto> GetOrderDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from o in context.Orders
                             join od in context.OrderDetails
                             on o.OrderId equals od.Id
                             join s in context.Shippers
                             on o.ShipperId equals s.ShipperId
                             join e in context.Employees
                             on o.EmployeeId equals e.EmployeeId
                             join c in context.Customers
                             on o.CustomerId equals c.CustomerId
                             join p in context.Products
                             on od.ProductId equals p.ProductId
                             join ct in context.Categories
                             on p.CategoryId equals ct.CategoryId
                             join su in context.Suppliers
                             on p.SupplierId equals su.SupplierId

                             select new OrderDto
                             {
                                 OrderId = o.OrderId,
                                 ProductId = od.ProductId,
                                 OrderDate = o.OrderDate,
                                 CompanyName = c.CompanyName,
                                 Amount = od.Amount,
                                 PiecePrice = od.PiecePrice,
                                 ContactName = c.ContactName,
                                 CustomerCity = c.CustomerCity,
                                 CustomerId = c.CustomerId,
                                 Discount = od.Discount,
                                 EmployeeId = e.EmployeeId,
                                 EmployeeCity = e.EmployeeCity,
                                 EmployeeFirsName = e.EmployeeFirsName,
                                 EmployeeLastName = e.EmployeeLastName,
                                 ShipperId = s.ShipperId,
                                 ShipName = o.ShipName,
                                 ShipCompanyName = s.ShipCompanyName,
                                 ShipCompanyPhone = s.ShipCompanyPhone,
                                 ShipCity = o.ShipCity,
                                 ShipCountry = o.ShipCountry,
                                 CategoryId = p.CategoryId,
                                 CategoryName = ct.CategoryName,
                                 CategoryDescription = ct.CategoryDescription,
                                 SupplierId = p.SupplierId,
                                 SupplierCompanyName = su.SupplierCompanyName,
                                 SupplierContactName = su.SupplierContactName,
                                 SupplierCity = su.SupplierCity
                             };

                return result.ToList();
            }
        }
        public Task<List<OrderDto>> GetOrderDetailsAsync()
        {
            NorthwindContext context = new NorthwindContext();

            var result = from o in context.Orders
                         join od in context.OrderDetails
                         on o.OrderId equals od.Id
                         join s in context.Shippers
                         on o.ShipperId equals s.ShipperId
                         join e in context.Employees
                         on o.EmployeeId equals e.EmployeeId
                         join c in context.Customers
                         on o.CustomerId equals c.CustomerId
                         join p in context.Products
                         on od.ProductId equals p.ProductId
                         join ct in context.Categories
                         on p.CategoryId equals ct.CategoryId
                         join su in context.Suppliers
                         on p.SupplierId equals su.SupplierId

                         select new OrderDto
                         {
                             OrderId = o.OrderId,
                             ProductId = od.ProductId,
                             OrderDate = o.OrderDate,
                             CompanyName = c.CompanyName,
                             Amount = od.Amount,
                             PiecePrice = od.PiecePrice,
                             ContactName = c.ContactName,
                             CustomerCity = c.CustomerCity,
                             CustomerId = c.CustomerId,
                             Discount = od.Discount,
                             EmployeeId = e.EmployeeId,
                             EmployeeCity = e.EmployeeCity,
                             EmployeeFirsName = e.EmployeeFirsName,
                             EmployeeLastName = e.EmployeeLastName,
                             ShipperId = s.ShipperId,
                             ShipName = o.ShipName,
                             ShipCompanyName = s.ShipCompanyName,
                             ShipCompanyPhone = s.ShipCompanyPhone,
                             ShipCity = o.ShipCity,
                             ShipCountry = o.ShipCountry,
                             CategoryId = p.CategoryId,
                             CategoryName = ct.CategoryName,
                             CategoryDescription = ct.CategoryDescription,
                             SupplierId = p.SupplierId,
                             SupplierCompanyName = su.SupplierCompanyName,
                             SupplierContactName = su.SupplierContactName,
                             SupplierCity = su.SupplierCity
                         };
            return result.ToListAsync();
        }
    }
}
