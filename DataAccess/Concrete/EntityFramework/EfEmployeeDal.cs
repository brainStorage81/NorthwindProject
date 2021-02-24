using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, NorthwindContext>, IEmployeeDal
    {
        public List<EmployeeDto> GetEmployeeDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from et in context.EmployeeTerritories
                             join e in context.Employees
                             on et.EmployeeId equals e.EmployeeId
                             join t in context.Territories
                             on et.TerritoryId equals t.TerritoryId
                             join r in context.Regions
                             on t.RegionId equals r.RegionId

                             select new EmployeeDto
                             {
                                 EmployeeId = e.EmployeeId,
                                 EmployeeFirsName = e.EmployeeFirsName,
                                 EmployeeLastName = e.EmployeeLastName,
                                 EmployeeCity = e.EmployeeCity,
                                 RegionId = r.RegionId,
                                 RegionDescription = r.RegionDescription,
                                 TerritoryId = t.TerritoryId,
                                 TerritoryDescription = t.TerritoryDescription
                             };
                return result.ToList();
            };
        }

        public Task<List<EmployeeDto>> GetEmployeeDetailsAsync()
        {
            NorthwindContext context = new NorthwindContext();

            var result = from et in context.EmployeeTerritories
                         join e in context.Employees
                         on et.EmployeeId equals e.EmployeeId
                         join t in context.Territories
                         on et.TerritoryId equals t.TerritoryId
                         join r in context.Regions
                         on t.RegionId equals r.RegionId

                         select new EmployeeDto
                         {
                             EmployeeId = e.EmployeeId,
                             EmployeeFirsName = e.EmployeeFirsName,
                             EmployeeLastName = e.EmployeeLastName,
                             EmployeeCity = e.EmployeeCity,
                             RegionId = r.RegionId,
                             RegionDescription = r.RegionDescription,
                             TerritoryId = t.TerritoryId,
                             TerritoryDescription = t.TerritoryDescription
                         };
            return result.ToListAsync();

        }
    }
}
