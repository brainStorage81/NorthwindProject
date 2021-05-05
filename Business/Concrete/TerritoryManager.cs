using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class TerritoryManager : ITerritoryService
    {
        ITerritoryDal _territoryDal;

        public TerritoryManager(ITerritoryDal territoryDal)
        {
            _territoryDal = territoryDal;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("territory.add,admin")]
        [ValidationAspect(typeof(TerritoryValidator), Priority = 1)]
        [CacheRemoveAspect("ITerritoryService.Get")]
        public IResult Add(Territory territory)
        {
            //HandleException.AttributeException(() => ValidationTool.Validate(new TerritoryValidator(), territory));
            //HandleException.ClassException(() => _territoryDal.Add(territory));

            _territoryDal.Add(territory);
            return new SuccessResult(TerritoryMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("territory.add,admin")]
        [ValidationAspect(typeof(TerritoryValidator))]
        [CacheRemoveAspect("ITerritoryService.Get")]
        public IResult AddAsync(Territory territory)
        {
            _territoryDal.AddAsync(territory);
            return new SuccessResult(TerritoryMessages.Added);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Territory territory)
        {

            Add(territory);
            if (territory.TerritoryDescription.Length==0)
            {
                throw new Exception(TerritoryMessages.TerritoryDescriptionCannotBeEmpty);
            }           
            return new SuccessResult(TerritoryMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("territory.add,admin")]
        [ValidationAspect(typeof(TerritoryValidator))]
        [CacheRemoveAspect("ITerritoryService.Get")]
        public IResult Update(Territory territory)
        {
            _territoryDal.Update(territory);
            return new SuccessResult(TerritoryMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("territory.add,admin")]
        [ValidationAspect(typeof(TerritoryValidator))]
        [CacheRemoveAspect("ITerritoryService.Get")]
        public IResult UpdateAsync(Territory territory)
        {
            _territoryDal.UpdateAsync(territory);
            return new SuccessResult(TerritoryMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("territory.del,admin")]
        [CacheRemoveAspect("ITerritoryService.Get")]
        public IResult Delete(Territory territory)
        {
            _territoryDal.Delete(territory);
            return new SuccessResult(TerritoryMessages.Deleted);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("territory.del,admin")]
        [CacheRemoveAspect("ITerritoryService.Get")]
        public IResult DeleteAsync(Territory territory)
        {
            _territoryDal.DeleteAsync(territory);            
            return new SuccessResult(TerritoryMessages.Deleted);
        }

        [CacheAspect]
        [SecuredOperation("territory.list,admin")]
        public IDataResult<Territory> Get(Expression<Func<Territory, bool>> filter)
        {
            var _get = _territoryDal.Get(filter);
            
            if (_get==null)
            {
                return new ErrorDataResult<Territory>(TerritoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<Territory>(_get, TerritoryMessages.TerritoryListed);
        }

        [CacheAspect]
        [SecuredOperation("territory.list,admin")]
        public IDataResult<Territory> GetAsync(Expression<Func<Territory, bool>> filter)
        {
            var _getAsync = _territoryDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Territory>(TerritoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<Territory>(_getAsync, TerritoryMessages.TerritoryListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("territory.list,admin")]
        public IDataResult<List<Territory>> GetAll(Expression<Func<Territory, bool>> filter = null)
        {
            var _getAll = _territoryDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Territory>>(TerritoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Territory>>(_getAll, TerritoryMessages.TerritoriesListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("territory.list,admin")]
        public IDataResult<List<Territory>> GetAllAsync(Expression<Func<Territory, bool>> filter = null)
        {
            var _getAllAsync = _territoryDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Territory>>(TerritoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Territory>>(_getAllAsync, TerritoryMessages.TerritoriesListed);
        }

    }
}
