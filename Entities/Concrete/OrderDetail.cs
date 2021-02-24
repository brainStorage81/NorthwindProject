using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OrderDetail:IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }        
        public decimal PiecePrice { get; set; }
        public short Amount { get; set; }
        public float Discount { get; set; }

    }
}
