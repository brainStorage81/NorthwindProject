using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>, IAsyncEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        Task<List<OperationClaim>> GetClaimsAsync(User user);        

        List<UserDto> GetAllUsersDetail();
        Task<List<UserDto>> GetAllUsersDetailAsync();

        List<UserDto> GetAllUsersDetailWithFilter(Expression<Func<UserDto, bool>> filter = null);
        Task<List<UserDto>> GetAllUsersDetailWithFilterAsync(Expression<Func<UserDto, bool>> filter = null);

        List<UserDto> GetAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstain(string constain);
        Task<List<UserDto>> GetAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstainAsync(string constain);

        UserDto GetByUserId(int entity);
        Task<UserDto> GetByUserIdAsync(int entity);

    }
}
