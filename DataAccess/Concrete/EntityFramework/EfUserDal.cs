using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, IconTrendContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetUsersDtos(Expression<Func<UserDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
