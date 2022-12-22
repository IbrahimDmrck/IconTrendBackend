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
    public class EfKongreDal : EfEntityRepositoryBase<Kongre, IconTrendContext>, IKongreDal
    {
        public List<KongreDetailDto> GetKongreDetails(Expression<Func<KongreDetailDto, bool>> filter = null)
        {
            using (var context=new IconTrendContext())
            {
                var result = from kongre in context.Kongres
                             select new KongreDetailDto
                             {
                                 KongreId = kongre.KongreId,
                                 KongreAdi = kongre.KongreAdi,
                                 KongreHakkinda = kongre.KongreHakkinda,
                                 KongreBaskani = kongre.KongreBaskani,
                                 BilimKurulu = kongre.BilimKurulu,
                                 KongreKonusu = kongre.KongreKonusu,
                                 KongreAdresi = kongre.KongreAdresi,
                                 KongreDuzenlemeKurulu = kongre.KongreDuzenlemeKurulu,
                                 KongreTarihi = kongre.KongreTarihi,
                                 KongreImages = ((from kongreImg in context.KongreImages
                                                  where (kongre.KongreId == kongreImg.KongreId)
                                                  select new KongreImage
                                                  {
                                                      Id = kongreImg.Id,
                                                      KongreId = kongreImg.KongreId,
                                                      Date = kongreImg.Date,
                                                      ImagePath = kongreImg.ImagePath
                                                  }).ToList()).Count == 0
                                                ? new List<KongreImage> { new KongreImage { Id = -1, KongreId = kongre.KongreId, Date = DateTime.Now, ImagePath = "/images/default.jpg" } }
                                                : (from KongreImage in context.KongreImages
                                                   where (kongre.KongreId == KongreImage.KongreId)
                                                   select new KongreImage
                                                   {
                                                       Id = KongreImage.Id,
                                                       KongreId = KongreImage.KongreId,
                                                       Date = KongreImage.Date,
                                                       ImagePath = KongreImage.ImagePath
                                                   }).ToList()

                             };
                return filter == null
             ? result.ToList()
             : result.Where(filter).ToList();
            }
        }
    }
}

