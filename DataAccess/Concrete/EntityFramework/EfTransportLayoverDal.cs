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
                             select new TransportLayoverDetailDto
                             {
                                 TransportId = transport.TransportId,
                                 Capacity = transport.Capacity,
                                 Description = transport.Description,
                                 MinDemand = transport.MinDemand,
                                 Price = transport.Price,
                                 TransportLayoverImages = ((from trImg in context.TransportLayoverImages
                                                            where (transport.TransportId == trImg.TransportLayoverId)
                                                            select new TransportLayoverImage
                                                            {
                                                                Id = trImg.Id,
                                                                TransportLayoverId = trImg.TransportLayoverId,
                                                                Date = trImg.Date,
                                                                ImagePath = trImg.ImagePath
                                                            }).ToList()).Count == 0 ?
                                                          new List<TransportLayoverImage> { new TransportLayoverImage { Id = -1, TransportLayoverId = transport.TransportId, Date = DateTime.Now, ImagePath = "/images/default.jpg" } } :
                                                          (from trImg in context.TransportLayoverImages
                                                           where (transport.TransportId == trImg.TransportLayoverId)
                                                           select new TransportLayoverImage
                                                           {
                                                               Id = trImg.Id,
                                                               TransportLayoverId = trImg.TransportLayoverId,
                                                               Date = trImg.Date,
                                                               ImagePath = trImg.ImagePath
                                                           }).ToList()
                             };

                return filter == null
                   ? result.ToList()
                   : result.Where(filter).ToList();

            }
        }
    }
}
