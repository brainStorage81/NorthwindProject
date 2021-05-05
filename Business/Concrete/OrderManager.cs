using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("order.add,admin")]
        [ValidationAspect(typeof(OrderValidator), Priority = 1)]
        [CacheRemoveAspect("IOrderService.Get")]
        public IResult Add(Order order)
        {            
            _orderDal.Add(order);
            return new SuccessResult(OrderMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("order.add,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public IResult AddAsync(Order order)
        {            
            _orderDal.AddAsync(order);
            return new SuccessResult(OrderMessages.Added);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Order order)
        {
            
            Add(order);
            if (order.ShipName.StartsWith("SHP"))
            {
                throw new Exception(OrderMessages.ShipNameInvalid);
            }
            return new SuccessResult(OrderMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("order.add,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]        
        public IResult Update(Order order)
        {            
            _orderDal.Update(order);
            return new SuccessResult(OrderMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("order.add,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public IResult UpdateAsync(Order order)
        {            
            _orderDal.UpdateAsync(order);
            return new SuccessResult(OrderMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("order.del,admin")]
        [CacheRemoveAspect("IOrderService.Get")]
        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(OrderMessages.Deleted);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("order.del,admin")]
        [CacheRemoveAspect("IOrderService.Get")]
        public IResult DeleteAsync(Order order)
        {
            _orderDal.DeleteAsync(order);
            return new SuccessResult(OrderMessages.Deleted);
        }

        [CacheAspect]
        [SecuredOperation("order.list,admin")]
        public IDataResult<Order> Get(Expression<Func<Order, bool>> filter)
        {
            var _get = _orderDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Order>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<Order>(_get, OrderMessages.OrderListed);
        }

        [CacheAspect]
        [SecuredOperation("order.list,admin")]
        public IDataResult<Order> GetAsync(Expression<Func<Order, bool>> filter)
        {
            var _getAsync = _orderDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Order>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<Order>(_getAsync, OrderMessages.OrderListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("order.list,admin")]
        public IDataResult<List<Order>> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            var _getAll = _orderDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Order>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Order>>(_getAll, OrderMessages.OrdersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("order.list,admin")]
        public IDataResult<List<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null)
        {
            var _getAllAsync = _orderDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Order>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Order>>(_getAllAsync, OrderMessages.OrdersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("order.list,admin")]
        public IDataResult<List<Order>> GetAllByShipCityWhereConstain(string constain)
        {
            var _getAllByShipCityWhereConstain = _orderDal.GetAllByShipCityWhereConstain(constain);

            if (_getAllByShipCityWhereConstain == null)
            {
                return new ErrorDataResult<List<Order>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Order>>(_getAllByShipCityWhereConstain, OrderMessages.OrdersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("order.list,admin")]
        public IDataResult<List<Order>> GetAllByShipCityWhereConstainAsync(string constain)
        {
            var _getAllByShipCityWhereConstainAsync = _orderDal.GetAllByShipCityWhereConstainAsync(constain).Result;

            if (_getAllByShipCityWhereConstainAsync == null)
            {
                return new ErrorDataResult<List<Order>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Order>>(_getAllByShipCityWhereConstainAsync, OrderMessages.OrdersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("order.list,admin")]
        public IDataResult<List<OrderDto>> GetOrderDetails()
        {
            var _getOrderDetails = _orderDal.GetOrderDetails();

            if (_getOrderDetails == null)
            {
                return new ErrorDataResult<List<OrderDto>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OrderDto>>(_getOrderDetails, OrderMessages.OrderDetailsListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("order.list,admin")]
        public IDataResult<List<OrderDto>> GetOrderDetailsAsync()
        {
            var _getOrderDetailsAsync = _orderDal.GetOrderDetailsAsync().Result;

            if (_getOrderDetailsAsync == null)
            {
                return new ErrorDataResult<List<OrderDto>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OrderDto>>(_getOrderDetailsAsync, OrderMessages.OrderDetailsListed);
        }
    }
}
