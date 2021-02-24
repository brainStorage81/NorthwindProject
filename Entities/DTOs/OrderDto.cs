using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDto:IDto
    {
        public int OrderId { get; set; }

        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string CustomerCity { get; set; }

        public int ProductId { get; set; }        
        public decimal PiecePrice { get; set; }
        public short Amount { get; set; }
        public float Discount { get; set; }

        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
                
        public int EmployeeId { get; set; }
        public string EmployeeFirsName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeCity { get; set; }

        public int ShipperId { get; set; }
        public string ShipCompanyName { get; set; }
        public string ShipCompanyPhone { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public int SupplierId { get; set; }
        public string SupplierCompanyName { get; set; }
        public string SupplierContactName { get; set; }
        public string SupplierCity { get; set; }
    }
}
