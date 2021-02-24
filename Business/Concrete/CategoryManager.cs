using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Exceptions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager: ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new CategoryValidator(), category));
            HandleException.ClassException(() => _categoryDal.Add(category));
            return new SuccessResult(CategoryMessages.Added);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult AddAsync(Category category)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new CategoryValidator(), category));
            HandleException.ClassException(() => _categoryDal.AddAsync(category));
            return new SuccessResult(CategoryMessages.Added);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category category)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new CategoryValidator(), category));
            HandleException.ClassException(() => _categoryDal.Update(category));
            return new SuccessResult(CategoryMessages.Updated);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult UpdateAsync(Category category)
        {
            HandleException.AttributeException(() => ValidationTool.Validate(new CategoryValidator(), category));
            HandleException.ClassException(() => _categoryDal.UpdateAsync(category));
            return new SuccessResult(CategoryMessages.Updated);
        }

        public IResult Delete(Category category)
        {
            HandleException.ClassException(() => _categoryDal.Delete(category));
            return new SuccessResult(CategoryMessages.Deleted);
        }

        public IResult DeleteAsync(Category category)
        {
            HandleException.ClassException(() => _categoryDal.DeleteAsync(category));
            return new SuccessResult(CategoryMessages.Deleted);
        }

        public IDataResult<Category> Get(Expression<Func<Category, bool>> filter)
        {
            var _get = _categoryDal.Get(filter);

            if (_get == null)
            {
                return new ErrorDataResult<Category>(CategoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<Category>(_get, CategoryMessages.CategoryListed);
        }

        public IDataResult<Category> GetAsync(Expression<Func<Category, bool>> filter)
        {
            var _getAsync = _categoryDal.GetAsync(filter).Result;

            if (_getAsync == null)
            {
                return new ErrorDataResult<Category>(CategoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<Category>(_getAsync, CategoryMessages.CategoryListed);
        }

        public IDataResult<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            var _getAll = _categoryDal.GetAll(filter);

            if (_getAll == null)
            {
                return new ErrorDataResult<List<Category>>(CategoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Category>>(_getAll, CategoryMessages.CategoryListed);
        }

        public IDataResult<List<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null)
        {
            var _getAllAsync = _categoryDal.GetAllAsync(filter).Result;

            if (_getAllAsync == null)
            {
                return new ErrorDataResult<List<Category>>(CategoryMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<Category>>(_getAllAsync, CategoryMessages.CategoryListed);
        }
    }
}
