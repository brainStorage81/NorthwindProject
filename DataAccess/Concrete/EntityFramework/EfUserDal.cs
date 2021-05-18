using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on oc.Id equals uoc.OperationClaimId
                             where uoc.UserId == user.Id
                             select new OperationClaim { Id = oc.Id, Name = oc.Name };
                return result.ToList();

            }
        }

        public Task<List<OperationClaim>> GetClaimsAsync(User user)
        {
            NorthwindContext context = new NorthwindContext();
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on oc.Id equals uoc.OperationClaimId
                             where uoc.UserId == user.Id
                             select new OperationClaim { Id = oc.Id, Name = oc.Name };
                return result.ToListAsync();

            }
        }

        public List<UserDto> GetAllUsersDetailWithFilter(Expression<Func<UserDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
               if(filter == null)
                {
                    var result = from oc in context.OperationClaims
                                 join uoc in context.UserOperationClaims
                                 on oc.Id equals uoc.OperationClaimId
                                 join u in context.Users
                                 on uoc.UserId equals u.Id

                                 select new UserDto
                                 {
                                     UserId = u.Id,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     Email = u.Email,
                                     ClaimName = oc.Name,
                                     Status = u.Status
                                 };

                    return result.ToList();
                }
                else
                {
                    var result2 = from oc in context.OperationClaims
                                  join uoc in context.UserOperationClaims
                                  on oc.Id equals uoc.OperationClaimId
                                  join u in context.Users
                                  on uoc.UserId equals u.Id                                  

                                  select new UserDto
                                  {
                                      UserId = u.Id,
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      Email = u.Email,
                                      ClaimName = oc.Name,
                                      Status = u.Status
                                  };



                    return result2.Where(filter).ToList();
                }
            }
        }

        public Task<List<UserDto>> GetAllUsersDetailWithFilterAsync(Expression<Func<UserDto, bool>> filter = null)
        {
            NorthwindContext context = new NorthwindContext();
            {
                if (filter == null)
                {
                    var result = from oc in context.OperationClaims
                                 join uoc in context.UserOperationClaims
                                 on oc.Id equals uoc.OperationClaimId
                                 join u in context.Users
                                 on uoc.UserId equals u.Id

                                 select new UserDto
                                 {
                                     UserId = u.Id,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     Email = u.Email,
                                     ClaimName = oc.Name,
                                     Status = u.Status
                                 };

                    return result.ToListAsync();
                }
                else
                {
                    var result2 = from oc in context.OperationClaims
                                  join uoc in context.UserOperationClaims
                                  on oc.Id equals uoc.OperationClaimId
                                  join u in context.Users
                                  on uoc.UserId equals u.Id

                                  select new UserDto
                                  {
                                      UserId = u.Id,
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      Email = u.Email,
                                      ClaimName = oc.Name,
                                      Status = u.Status
                                  };



                    return result2.Where(filter).ToListAsync();
                }
            }
        }

        public List<UserDto> GetAllUsersDetail()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on oc.Id equals uoc.OperationClaimId
                             join u in context.Users
                             on uoc.UserId equals u.Id

                             select new UserDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ClaimName = oc.Name,
                                 Status = u.Status
                             };

                return result.ToList();
            }
        }

        public Task<List<UserDto>> GetAllUsersDetailAsync()
        {
            NorthwindContext context = new NorthwindContext();
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on oc.Id equals uoc.OperationClaimId
                             join u in context.Users
                             on uoc.UserId equals u.Id

                             select new UserDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ClaimName = oc.Name,
                                 Status = u.Status
                             };

                return result.ToListAsync();
            }
        }

        public List<UserDto> GetAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstain(string constain)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on oc.Id equals uoc.OperationClaimId
                             join u in context.Users
                             on uoc.UserId equals u.Id
                             where u.FirstName.Contains(constain) | u.LastName.Contains(constain) | u.Email.Contains(constain)

                             select new UserDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ClaimName = oc.Name,
                                 Status = u.Status
                             };

                return result.ToList();
            }
        }

        public Task<List<UserDto>> GetAllUsersDetailByFirstNameOrLastNameOrEmailWhereConstainAsync(string constain)
        {
            NorthwindContext context = new NorthwindContext();
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on oc.Id equals uoc.OperationClaimId
                             join u in context.Users
                             on uoc.UserId equals u.Id
                             where u.FirstName.Contains(constain) | u.LastName.Contains(constain) | u.Email.Contains(constain)

                             select new UserDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ClaimName = oc.Name,
                                 Status = u.Status
                             };

                return result.ToListAsync();
            }
        }

        public UserDto GetByUserId(int entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on oc.Id equals uoc.OperationClaimId
                             join u in context.Users
                             on uoc.UserId equals u.Id
                             where u.Id.Equals(entity)

                             select new UserDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ClaimName = oc.Name,
                                 Status = u.Status
                             };

                return result.FirstOrDefault();
            }

        }

        public Task<UserDto> GetByUserIdAsync(int entity)
        {
            NorthwindContext context = new NorthwindContext();
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on oc.Id equals uoc.OperationClaimId
                             join u in context.Users
                             on uoc.UserId equals u.Id
                             where u.Id.Equals(entity)

                             select new UserDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ClaimName = oc.Name,
                                 Status = u.Status
                             };

                return result.FirstOrDefaultAsync();
            }

        }
        
    }
}
