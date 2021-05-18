using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult AddAsync(User user);
        IResult TransactionalOperation(User user);

        IResult Update(User user);
        IResult UpdateAsync(User user);

        IResult Delete(User user);
        IResult DeleteAsync(User user);

        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetByMailAsync(string email);

        IDataResult<UserDto> GetByUserId(int entity);
        IDataResult<UserDto> GetByUserIdAsync(int entity);

        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<OperationClaim>> GetClaimsAsync(User user);

        IDataResult<List<UserDto>> GetAllUsersDetail();
        IDataResult<List<UserDto>> GetAllUsersDetailAsync();

        IDataResult<List<UserDto>> GetAllUsersDetailWithFilter(Expression<Func<UserDto, bool>> filter = null);
        IDataResult<List<UserDto>> GetAllUsersDetailWithFilterAsync(Expression<Func<UserDto, bool>> filter = null);

        IDataResult<List<UserDto>> GetAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstain(string constain);
        IDataResult<List<UserDto>> GetAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstainAsync(string constain);
        
        
    }
}
