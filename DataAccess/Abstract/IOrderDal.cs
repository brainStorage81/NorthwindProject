using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>, IAsyncEntityRepository<Order>
    {
        List<OrderDto> GetOrderDetails();
        Task<List<OrderDto>> GetOrderDetailsAsync();
        List<Order> GetAllByShipCityWhereConstain(string entity);
        Task<List<Order>> GetAllByShipCityWhereConstainAsync(string entity);
        
    }
}

