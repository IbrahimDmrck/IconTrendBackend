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
    public class EfTransportLayoverDal : EfEntityRepositoryBase<TransportLayover, IconTrendContext>, ITransportLayoverDal
    {
        public List<TransportLayoverDto> GetTransportDetails(Expression<Func<TransportLayoverDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
