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

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("orderdetail.add,admin")]
        [ValidationAspect(typeof(OrderDetailValidator), Priority = 1)]
        [CacheRemoveAspect("IOrderDetailService.Get")]
        public IResult Add(OrderDetail orderDetail)
        {            
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult(OrderDetailMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("orderdetail.add,admin")]
        [ValidationAspect(typeof(OrderDetailValidator))]
        [CacheRemoveAspect("IOrderDetailService.Get")]
        public IResult AddAsync(OrderDetail orderDetail)
        {            
            _orderDetailDal.AddAsync(orderDetail);
            return new SuccessResult(OrderDetailMessages.Added);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(OrderDetail orderDetail)
        {
            
            Add(orderDetail);
            if (orderDetail.PiecePrice < 0)
            {
                throw new Exception(OrderDetailMessages.UnitPriceCannotBeNegativeValue);
            }
            return new SuccessResult(OrderDetailMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("orderdetail.add,admin")]
        [ValidationAspect(typeof(OrderDetailValidator))]
        [CacheRemoveAspect("IOrderDetailService.Get")]
        public IResult Update(OrderDetail orderDetail)
        {            
            _orderDetailDal.Update(orderDetail);
            return new SuccessResult(OrderDetailMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("orderdetail.add,admin")]
        [ValidationAspect(typeof(OrderDetailValidator))]
        [CacheRemoveAspect("IOrderDetailService.Get")]
        public IResult UpdateAsync(OrderDetail orderDetail)
        {            
            _orderDetailDal.UpdateAsync(orderDetail);
            return new SuccessResult(OrderDetailMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("orderdetail.del,admin")]        
        [CacheRemoveAspect("IOrderDetailService.Get")]
        public IResult Delete(OrderDetail orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
            return new SuccessResult(OrderDetailMessages.Deleted);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("orderdetail.del,admin")]
        [CacheRemoveAspect("IOrderDetailService.Get")]
        public IResult DeleteAsync(OrderDetail orderDetail)
        {
            _orderDetailDal.DeleteAsync(orderDetail);
            return new SuccessResult(OrderDetailMessages.Deleted);
        }

        [CacheAspect]
        [SecuredOperation("orderdetail.list,admin")]
        public IDataResult<OrderDetail> Get(Expression<Func<OrderDetail, bool>> filter)
        {
            var _get = _orderDetailDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<OrderDetail>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<OrderDetail>(_get, OrderDetailMessages.OrderDetailListed);
        }

        [CacheAspect]
        [SecuredOperation("orderdetail.list,admin")]
        public IDataResult<OrderDetail> GetAsync(Expression<Func<OrderDetail, bool>> filter)
        {
            var _getAsync = _orderDetailDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<OrderDetail>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<OrderDetail>(_getAsync, OrderDetailMessages.OrderDetailListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("orderdetail.list,admin")]
        public IDataResult<List<OrderDetail>> GetAll(Expression<Func<OrderDetail, bool>> filter = null)
        {
            var _getAll = _orderDetailDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<OrderDetail>>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OrderDetail>>(_getAll, OrderDetailMessages.OrderDetailsListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("orderdetail.list,admin")]
        public IDataResult<List<OrderDetail>> GetAllAsync(Expression<Func<OrderDetail, bool>> filter = null)
        {
            var _getAllAsync = _orderDetailDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<OrderDetail>>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OrderDetail>>(_getAllAsync, OrderDetailMessages.OrderDetailsListed);
        }

        [CacheAspect]
        [SecuredOperation("orderdetail.list,admin")]
        public IDataResult<List<OrderDetail>> GetByUnitPrice(decimal min, decimal max)
        {
            var _getByUnitPrice = _orderDetailDal.GetAll(od => od.PiecePrice >= min && od.PiecePrice <= max);

            if (_getByUnitPrice == null)
            {
                return new ErrorDataResult<List<OrderDetail>>(OrderDetailMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OrderDetail>>(_getByUnitPrice, OrderDetailMessages.OrderDetailListed);
        }

        [CacheAspect]
        [SecuredOperation("orderdetail.list,admin")]
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

