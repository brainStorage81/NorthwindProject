using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class EmployeeTerritory:IEntity
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }
    }
}
