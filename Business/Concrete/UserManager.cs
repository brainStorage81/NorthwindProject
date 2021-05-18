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
using Core.Entities.Concrete;
using Core.Utilities.ForBusiness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("user.add,admin")]
        [ValidationAspect(typeof(UserValidator), Priority = 1)]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(CheckIfUserEmailExists(user.Email));

            if (result != null)
            {
                return result;
            }

            _userDal.Add(user);
            return new SuccessResult(UserMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("user.add,admin")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult AddAsync(User user)
        {
            _userDal.AddAsync(user);
            return new SuccessResult(UserMessages.Added);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(User user)
        {
            Add(user);
            if (user.FirstName.Length > 20)
            {
                throw new Exception(UserMessages.UserFirsNameLimitValueExceeded);
            }
            return new SuccessResult(UserMessages.Added);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("user.add,admin")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new Result(true, UserMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("user.add,admin")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult UpdateAsync(User user)
        {
            _userDal.UpdateAsync(user);
            return new Result(true, UserMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("user.del,admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new Result(true, UserMessages.Updated);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("user.del,admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult DeleteAsync(User user)
        {
            _userDal.DeleteAsync(user);
            return new Result(true, UserMessages.Updated);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("user.list,admin")]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var _getClaims = _userDal.GetClaims(user);

            if (_getClaims == null)
            {
                return new ErrorDataResult<List<OperationClaim>>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OperationClaim>>(_getClaims, UserMessages.UserClaimListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("user.list,admin")]
        public IDataResult<List<OperationClaim>> GetClaimsAsync(User user)
        {
            var _getClaimsAsync = _userDal.GetClaimsAsync(user).Result;

            if (_getClaimsAsync == null)
            {
                return new ErrorDataResult<List<OperationClaim>>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<OperationClaim>>(_getClaimsAsync, UserMessages.UserClaimListed);
        }

        [CacheAspect]
        [SecuredOperation("user.list,admin")]
        public IDataResult<User> GetByMail(string email)
        {
            var _getByMail= _userDal.Get(u => u.Email == email);

            if (_getByMail == null)
            {
                return new ErrorDataResult<User>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<User>(_getByMail, UserMessages.UserEmailAlreadyExists);

        }

        [CacheAspect]
        [SecuredOperation("user.list,admin")]
        public IDataResult<User> GetByMailAsync(string email)
        {
            var _getByMailAsync = _userDal.GetAsync(u => u.Email == email).Result;

            if (_getByMailAsync == null)
            {
                return new ErrorDataResult<User>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<User>(_getByMailAsync, UserMessages.UserEmailAlreadyExists);

        }

        [CacheAspect]
        [SecuredOperation("user.list,admin")]
        public IDataResult<UserDto> GetByUserId(int entity)
        {
            var _getByUserId = _userDal.GetByUserId(entity);

            if (_getByUserId == null)
            {
                return new ErrorDataResult<UserDto>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<UserDto>(_getByUserId, UserMessages.UserListed);
        }

        [CacheAspect]
        [SecuredOperation("user.list,admin")]
        public IDataResult<UserDto> GetByUserIdAsync(int entity)
        {
            var _getByUserIdAsync = _userDal.GetByUserIdAsync(entity).Result;

            if (_getByUserIdAsync == null)
            {
                return new ErrorDataResult<UserDto>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<UserDto>(_getByUserIdAsync, UserMessages.UserListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("user.list,admin")]
        public IDataResult<List<UserDto>> GetAllUsersDetail()
        {
            var _getAllUsersDetail = _userDal.GetAllUsersDetail();

            if (_getAllUsersDetail == null)
            {
                return new ErrorDataResult<List<UserDto>>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<UserDto>>(_getAllUsersDetail, UserMessages.UsersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("user.list,admin")]
        public IDataResult<List<UserDto>> GetAllUsersDetailAsync()
        {
            var _getAllUsersDetailAsync = _userDal.GetAllUsersDetailAsync().Result;

            if (_getAllUsersDetailAsync == null)
            {
                return new ErrorDataResult<List<UserDto>>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<UserDto>>(_getAllUsersDetailAsync, UserMessages.UsersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("user.list,admin")]
        public IDataResult<List<UserDto>> GetAllUsersDetailWithFilter(Expression<Func<UserDto, bool>> filter = null)
        {
            var _getAllUsersDetailWithFilter = _userDal.GetAllUsersDetailWithFilter(filter);

            if (_getAllUsersDetailWithFilter == null)
            {
                return new ErrorDataResult<List<UserDto>>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<UserDto>>(_getAllUsersDetailWithFilter, UserMessages.UsersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("user.list,admin")]
        public IDataResult<List<UserDto>> GetAllUsersDetailWithFilterAsync(Expression<Func<UserDto, bool>> filter = null)
        {
            var _getAllUsersDetailWithFilterAsync = _userDal.GetAllUsersDetailWithFilterAsync(filter).Result;

            if (_getAllUsersDetailWithFilterAsync == null)
            {
                return new ErrorDataResult<List<UserDto>>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<UserDto>>(_getAllUsersDetailWithFilterAsync, UserMessages.UsersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("user.list,admin")]
        public IDataResult<List<UserDto>> GetAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstain(string constain)
        {
            var _getAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstain = _userDal.GetAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstain(constain);

            if (_getAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstain == null)
            {
                return new ErrorDataResult<List<UserDto>>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<UserDto>>(_getAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstain, UserMessages.UsersListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        [SecuredOperation("user.list,admin")]
        public IDataResult<List<UserDto>> GetAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstainAsync(string constain)
        {
            var _getAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstainAsync = _userDal.GetAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstainAsync(constain).Result;

            if (_getAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstainAsync == null)
            {
                return new ErrorDataResult<List<UserDto>>(UserMessages.RecordNotFound);
            }
            return new SuccessDataResult<List<UserDto>>(_getAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstainAsync, UserMessages.UsersListed);
        }



        //BussinerRules
        private IResult CheckIfUserEmailExists(string email)
        {
            var result = _userDal.GetAll(u => u.Email == email);
            if (result != null)
            {
                return new ErrorResult(UserMessages.UserEmailAlreadyExists);
            }
            return new SuccessResult();

        }

        
    }
}
