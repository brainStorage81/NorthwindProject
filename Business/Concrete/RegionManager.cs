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
    public class RegionManager : IRegionService
    {
        IRegionDal _regionDal;

        public RegionManager(IRegionDal regionDal)
        {
            _regionDal = regionDal;
        }

        [ValidationAspect(typeof(RegionValidator))]
        public IResult Add(Region region)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new RegionValidator(), region));
            HandleException.ClassException(() => _regionDal.Add(region));
            return new SuccessResult(RegionMessages.Added);
        }

        [ValidationAspect(typeof(RegionValidator))]
        public IResult AddAsync(Region region)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new RegionValidator(), region));
            HandleException.ClassException(() => _regionDal.AddAsync(region));
            return new SuccessResult(RegionMessages.Added);
        }

        [ValidationAspect(typeof(RegionValidator))]
        public IResult Update(Region region)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new RegionValidator(), region));
            HandleException.ClassException(() => _regionDal.Update(region));
            return new SuccessResult(RegionMessages.Updated);
        }

        [ValidationAspect(typeof(RegionValidator))]
        public IResult UpdateAsync(Region region)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new RegionValidator(), region));
            HandleException.ClassException(() => _regionDal.UpdateAsync(region));
            return new SuccessResult(RegionMessages.Updated);
        }

        public IResult Delete(Region region)
        {
            HandleException.ClassException(() => _regionDal.Delete(region));
            return new SuccessResult(RegionMessages.Deleted);
        }

        public IResult DeleteAsync(Region region)
        {
            HandleException.ClassException(() => _regionDal.DeleteAsync(region));
            return new SuccessResult(RegionMessages.Deleted);
        }

        public IDataResult<Region> Get(Expression<Func<Region, bool>> filter)
        {
            var _get = _regionDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Region>(RegionMessages.RecordNotFound);
            }
            return new SuccessDataResult<Region>(_get, RegionMessages.RegionListed);
        }

        public IDataResult<Region> GetAsync(Expression<Func<Region, bool>> filter)
        {
            var _getAsync = _regionDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Region>(RegionMessages.RecordNotFound);
            }
            return new SuccessDataResult<Region>(_getAsync, RegionMessages.RegionListed);
        }

        public IDataResult<List<Region>> GetAll(Expression<Func<Region, bool>> filter = null)
        {
            var _getAll = _regionDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Region>>(RegionMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Region>>(_getAll, RegionMessages.RegionsListed);
        }

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
