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
        public List<TransportLayoverDetailDto> GetTransportDetails(Expression<Func<TransportLayoverDetailDto, bool>> filter = null)
        {
            using (var context = new IconTrendContext())
            {
                var result = from transport in context.TransportLayovers
                             join image in context.TransportLayoverImages
                            on transport.TransportId equals image.TransportLayoverId
                             select new TransportLayoverDetailDto
                             {
                                 TransportId = transport.TransportId,
                                 Capacity = transport.Capacity,
                                 Description = transport.Description,
                                 MinDemand = transport.MinDemand,
                                 Price = transport.Price,
                                 TransportLayoverImages = ((from ti in context.TransportLayoverImages
                                                            where
                  (transport.TransportId == ti.TransportLayoverId)
                                                            select new TransportLayoverImage
                                                            {
                                                                Id = ti.Id,
                                                                TransportLayoverId = ti.TransportLayoverId,
                                                                Date = ti.Date,
                                                                ImagePath = ti.ImagePath
                                                            }).ToList()).Count() == 0
                                                          ? null
                                                          : (from ti in context.TransportLayoverImages
                                                             where (transport.TransportId == ti.TransportLayoverId)
                                                             select new TransportLayoverImage
                                                             {
                                                                 Id = ti.Id,
                                                                 TransportLayoverId = ti.TransportLayoverId,
                                                                 Date = ti.Date,
                                                                 ImagePath = ti.ImagePath
                                                             }).ToList()
                             };

                return filter == null
                   ? result.ToList()
                   : result.Where(filter).ToList();

            }
        }
    }
}
