using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Supplier:IEntity
    {
        public int SupplierId { get; set; }
        public string SupplierCompanyName { get; set; }
        public string SupplierContactName { get; set; }
        public string SupplierCity { get; set; }        
    }
}
