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

namespace Business.Concrete
{
    public class TerritoryManager : ITerritoryService
    {
        ITerritoryDal _territoryDal;

        public TerritoryManager(ITerritoryDal territoryDal)
        {
            _territoryDal = territoryDal;
        }

        [ValidationAspect(typeof(TerritoryValidator))]
        public IResult Add(Territory territory)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new TerritoryValidator(), territory));
            HandleException.ClassException(() => _territoryDal.Add(territory));
            return new SuccessResult(TerritoryMessages.Added);
        }

        [ValidationAspect(typeof(TerritoryValidator))]
        public IResult AddAsync(Territory territory)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new TerritoryValidator(), territory));
            HandleException.ClassException(() => _territoryDal.AddAsync(territory));
            return new SuccessResult(TerritoryMessages.Added);
        }

        [ValidationAspect(typeof(TerritoryValidator))]
        public IResult Update(Territory territory)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new TerritoryValidator(), territory));
            HandleException.ClassException(() => _territoryDal.Update(territory));
            return new SuccessResult(TerritoryMessages.Updated);
        }

        [ValidationAspect(typeof(TerritoryValidator))]
        public IResult UpdateAsync(Territory territory)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new TerritoryValidator(), territory));
            HandleException.ClassException(() => _territoryDal.UpdateAsync(territory));
            return new SuccessResult(TerritoryMessages.Updated);
        }

        public IResult Delete(Territory territory)
        {
            HandleException.ClassException(() => _territoryDal.Delete(territory));
            return new SuccessResult(TerritoryMessages.Deleted);
        }

        public IResult DeleteAsync(Territory territory)
        {
            HandleException.ClassException(() => _territoryDal.DeleteAsync(territory));            
            return new SuccessResult(TerritoryMessages.Deleted);
        }

        public IDataResult<Territory> Get(Expression<Func<Territory, bool>> filter)
        {
            var _get = _territoryDal.Get(filter);
            
            if (_get==null)
            {
                return new ErrorDataResult<Territory>(TerritoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<Territory>(_get, TerritoryMessages.TerritoryListed);
        }

        public IDataResult<Territory> GetAsync(Expression<Func<Territory, bool>> filter)
        {
            var _getAsync = _territoryDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Territory>(TerritoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<Territory>(_getAsync, TerritoryMessages.TerritoryListed);
        }

        public IDataResult<List<Territory>> GetAll(Expression<Func<Territory, bool>> filter = null)
        {
            var _getAll = _territoryDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Territory>>(TerritoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Territory>>(_getAll, TerritoryMessages.TerritoriesListed);
        }

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
