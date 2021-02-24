using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Employee:IEntity
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirsName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeCity { get; set; }
    }
}
