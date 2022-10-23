using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCongressDal : EfEntityRepositoryBase<Congress, IconTrendContext>, ICongressDal
    {
        public List<CongressDetailDto> GetCongressDetails(Expression<Func<CongressDetailDto, bool>> filter = null)
        {
            using (var context=new IconTrendContext())
            {
                
            }
            throw new Exception();
        }
    }
}
