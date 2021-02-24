using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Shipper:IEntity
    {
        public int ShipperId { get; set; }
        public string ShipCompanyName { get; set; }
        public string ShipCompanyPhone { get; set; }
    }
}
