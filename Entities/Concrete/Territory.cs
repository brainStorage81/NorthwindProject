using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Territory : IEntity
    {
        public string TerritoryId { get; set; }
        public int RegionId { get; set; }
        public string TerritoryDescription { get; set; }
    }
}
