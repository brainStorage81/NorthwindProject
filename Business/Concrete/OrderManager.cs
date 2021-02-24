using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Exceptions;
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

        [ValidationAspect(typeof(OrderValidator))]
        public IResult Add(Order order)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new OrderValidator(), order));
            HandleException.ClassException(() => _orderDal.Add(order));
            return new SuccessResult(OrderMessages.Added);
        }

        [ValidationAspect(typeof(OrderValidator))]
        public IResult AddAsync(Order order)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new OrderValidator(), order));
            HandleException.ClassException(() => _orderDal.AddAsync(order));
            return new SuccessResult(OrderMessages.Added);
        }

        [ValidationAspect(typeof(OrderValidator))]
        public IResult Update(Order order)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new OrderValidator(), order));
            HandleException.ClassException(() => _orderDal.Update(order));
            return new SuccessResult(OrderMessages.Updated);
        }

        [ValidationAspect(typeof(OrderValidator))]
        public IResult UpdateAsync(Order order)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new OrderValidator(), order));
            HandleException.ClassException(() => _orderDal.UpdateAsync(order));
            return new SuccessResult(OrderMessages.Updated);
        }

        public IResult Delete(Order order)
        {
            HandleException.ClassException(() => _orderDal.Delete(order));
            return new SuccessResult(OrderMessages.Deleted);
        }

        public IResult DeleteAsync(Order order)
        {
            HandleException.ClassException(() => _orderDal.DeleteAsync(order));
            return new SuccessResult(OrderMessages.Deleted);
        }

        public IDataResult<Order> Get(Expression<Func<Order, bool>> filter)
        {
            var _get = _orderDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Order>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<Order>(_get, OrderMessages.OrderListed);
        }

        public IDataResult<Order> GetAsync(Expression<Func<Order, bool>> filter)
        {
            var _getAsync = _orderDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Order>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<Order>(_getAsync, OrderMessages.OrderListed);
        }

        public IDataResult<List<Order>> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            var _getAll = _orderDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Order>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Order>>(_getAll, OrderMessages.OrdersListed);
        }

        public IDataResult<List<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null)
        {
            var _getAllAsync = _orderDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Order>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Order>>(_getAllAsync, OrderMessages.OrdersListed);
        }

        public IDataResult<List<Order>> GetAllByShipCityWhereConstain(string constain)
        {
            var _getAllByShipCityWhereConstain = _orderDal.GetAllByShipCityWhereConstain(constain);

            if (_getAllByShipCityWhereConstain == null)
            {
                return new ErrorDataResult<List<Order>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Order>>(_getAllByShipCityWhereConstain, OrderMessages.OrdersListed);
        }

        public IDataResult<List<Order>> GetAllByShipCityWhereConstainAsync(string constain)
        {
            var _getAllByShipCityWhereConstainAsync = _orderDal.GetAllByShipCityWhereConstainAsync(constain).Result;

            if (_getAllByShipCityWhereConstainAsync == null)
            {
                return new ErrorDataResult<List<Order>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Order>>(_getAllByShipCityWhereConstainAsync, OrderMessages.OrdersListed);
        }

        public IDataResult<List<OrderDto>> GetOrderDetails()
        {
            var _getOrderDetails = _orderDal.GetOrderDetails();

            if (_getOrderDetails == null)
            {
                return new ErrorDataResult<List<OrderDto>>(OrderMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OrderDto>>(_getOrderDetails, OrderMessages.OrderDetailsListed);
        }

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
