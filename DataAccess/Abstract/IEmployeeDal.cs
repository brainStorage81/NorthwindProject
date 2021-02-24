using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>, IAsyncEntityRepository<Employee>
    {
        List<EmployeeDto> GetEmployeeDetails();
        Task<List<EmployeeDto>> GetEmployeeDetailsAsync();
    }
}
