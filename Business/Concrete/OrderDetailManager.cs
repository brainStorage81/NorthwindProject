using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        [ValidationAspect(typeof(OrderDetailValidator))]
        public IResult Add(OrderDetail orderDetail)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new OrderDetailValidator(), orderDetail));
            HandleException.ClassException(() => _orderDetailDal.Add(orderDetail));
            return new SuccessResult(OrderDetailMessages.Added);
        }

        [ValidationAspect(typeof(OrderDetailValidator))]
        public IResult AddAsync(OrderDetail orderDetail)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new OrderDetailValidator(), orderDetail));
            HandleException.ClassException(() => _orderDetailDal.AddAsync(orderDetail));
            return new SuccessResult(OrderDetailMessages.Added);
        }

        [ValidationAspect(typeof(OrderDetailValidator))]
        public IResult Update(OrderDetail orderDetail)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new OrderDetailValidator(), orderDetail));
            HandleException.ClassException(() => _orderDetailDal.Update(orderDetail));
            return new SuccessResult(OrderDetailMessages.Updated);
        }

        [ValidationAspect(typeof(OrderDetailValidator))]
        public IResult UpdateAsync(OrderDetail orderDetail)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new OrderDetailValidator(), orderDetail));
            HandleException.ClassException(() => _orderDetailDal.UpdateAsync(orderDetail));
            return new SuccessResult(OrderDetailMessages.Updated);
        }

        public IResult Delete(OrderDetail orderDetail)
        {
            HandleException.ClassException(() => _orderDetailDal.Delete(orderDetail));
            return new SuccessResult(OrderDetailMessages.Deleted);
        }

        public IResult DeleteAsync(OrderDetail orderDetail)
        {
            HandleException.ClassException(() => _orderDetailDal.DeleteAsync(orderDetail));
            return new SuccessResult(OrderDetailMessages.Deleted);
        }

        public IDataResult<OrderDetail> Get(Expression<Func<OrderDetail, bool>> filter)
        {
            var _get = _orderDetailDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<OrderDetail>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<OrderDetail>(_get, OrderDetailMessages.OrderDetailListed);
        }

        public IDataResult<OrderDetail> GetAsync(Expression<Func<OrderDetail, bool>> filter)
        {
            var _getAsync = _orderDetailDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<OrderDetail>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<OrderDetail>(_getAsync, OrderDetailMessages.OrderDetailListed);
        }

        public IDataResult<List<OrderDetail>> GetAll(Expression<Func<OrderDetail, bool>> filter = null)
        {
            var _getAll = _orderDetailDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<OrderDetail>>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OrderDetail>>(_getAll, OrderDetailMessages.OrderDetailsListed);
        }

        public IDataResult<List<OrderDetail>> GetAllAsync(Expression<Func<OrderDetail, bool>> filter = null)
        {
            var _getAllAsync = _orderDetailDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<OrderDetail>>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OrderDetail>>(_getAllAsync, OrderDetailMessages.OrderDetailsListed);
        }

        public IDataResult<List<OrderDetail>> GetByUnitPrice(decimal min, decimal max)
        {
            var _getByUnitPrice = _orderDetailDal.GetAll(od => od.PiecePrice >= min && od.PiecePrice <= max);

            if (_getByUnitPrice == null)
            {
                return new ErrorDataResult<List<OrderDetail>>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OrderDetail>>(_getByUnitPrice, OrderDetailMessages.OrderDetailListed);
        }

        public IDataResult<List<OrderDetail>> GetByUnitPriceAsync(decimal min, decimal max)
        {
            var _getByUnitPriceAsync = _orderDetailDal.GetAllAsync(od => od.PiecePrice >= min && od.PiecePrice <= max).Result;

            if (_getByUnitPriceAsync == null)
            {
                return new ErrorDataResult<List<OrderDetail>>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OrderDetail>>(_getByUnitPriceAsync, OrderDetailMessages.OrderDetailListed);
        }
    }
}

