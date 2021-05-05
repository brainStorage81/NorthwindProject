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
    public class RegionManager : IRegionService
    {
        IRegionDal _regionDal;

        public RegionManager(IRegionDal regionDal)
        {
            _regionDal = regionDal;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("region.add,admin")]
        [ValidationAspect(typeof(RegionValidator), Priority = 1)]
        [CacheRemoveAspect("IRegionService.Get")]
        public IResult Add(Region region)
        {            
            _regionDal.Add(region);
            return new SuccessResult(RegionMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("region.add,admin")]
        [ValidationAspect(typeof(RegionValidator))]
        [CacheRemoveAspect("IRegionService.Get")]
        public IResult AddAsync(Region region)
        {            
            _regionDal.AddAsync(region);
            return new SuccessResult(RegionMessages.Added);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Region region)
        {
            
            Add(region);
            if (region.RegionDescription.Length==0)
            {
                throw new Exception(RegionMessages.RegionDescriptionCannotBeEmpty);
            }
            return new SuccessResult(RegionMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("region.add,admin")]
        [ValidationAspect(typeof(RegionValidator))]
        [CacheRemoveAspect("IRegionService.Get")]
        public IResult Update(Region region)
        {            
            _regionDal.Update(region);
            return new SuccessResult(RegionMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("region.add,admin")]
        [ValidationAspect(typeof(RegionValidator))]
        [CacheRemoveAspect("IRegionService.Get")]
        public IResult UpdateAsync(Region region)
        {            
            _regionDal.UpdateAsync(region);
            return new SuccessResult(RegionMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("region.del,admin")]
        [CacheRemoveAspect("IRegionService.Get")]
        public IResult Delete(Region region)
        {
           _regionDal.Delete(region);
            return new SuccessResult(RegionMessages.Deleted);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("region.del,admin")]
        [CacheRemoveAspect("IRegionService.Get")]
        public IResult DeleteAsync(Region region)
        {
            _regionDal.DeleteAsync(region);
            return new SuccessResult(RegionMessages.Deleted);
        }

        [CacheAspect]
        [SecuredOperation("region.list,admin")]
        public IDataResult<Region> Get(Expression<Func<Region, bool>> filter)
        {
            var _get = _regionDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Region>(RegionMessages.RecordNotFound);
            }
            return new SuccessDataResult<Region>(_get, RegionMessages.RegionListed);
        }

        [CacheAspect]
        [SecuredOperation("region.list,admin")]
        public IDataResult<Region> GetAsync(Expression<Func<Region, bool>> filter)
        {
            var _getAsync = _regionDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Region>(RegionMessages.RecordNotFound);
            }
            return new SuccessDataResult<Region>(_getAsync, RegionMessages.RegionListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("region.list,admin")]
        public IDataResult<List<Region>> GetAll(Expression<Func<Region, bool>> filter = null)
        {
            var _getAll = _regionDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Region>>(RegionMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Region>>(_getAll, RegionMessages.RegionsListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("region.list,admin")]
        public IDataResult<List<Region>> GetAllAsync(Expression<Func<Region, bool>> filter = null)
        {
            var _getAllAsync = _regionDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Region>>(RegionMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Region>>(_getAllAsync, RegionMessages.RegionsListed);
        }
    }
}
