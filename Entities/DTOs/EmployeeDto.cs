using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EmployeeDto:IDto
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }
        public int RegionId { get; set; }
        public string EmployeeFirsName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeCity { get; set; }
        public string TerritoryDescription { get; set; }
        public string RegionDescription { get; set; }
    }
}
