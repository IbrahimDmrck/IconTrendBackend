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
                var result = from congress in context.Congresses
                             join president in context.CongressPresidents
                                 on congress.CongressPresidentId equals president.Id
                             select new CongressDetailDto
                             {
                                 CongressId=congress.CongressId,
                                 CongressName=congress.CongressName,
                                 CongressPresidentId=congress.CongressPresidentId,
                                 CogressPresidentName=president.CongressPresidentName,
                                 CongressAbout=congress.CongressAbout,
                                 CongressCity=congress.CongressCity,
                                 CongressPlace=congress.CongressPlace,
                                 CongressDate=congress.CongressDate,
                                 CongressStatus=congress.CongressStatus,
                                 Topics=((from t in context.Topics where
                                          (congress.CongressId==t.CongressId)
                                          select new Topic 
                                          {
                                            Id=t.Id,
                                            CongressId=t.CongressId,
                                            Category=t.Category,
                                            TopicName=t.TopicName
                                          }).ToList()).Count==0 
                                          ? null //new List<Topic> { new Topic { Category="Yok",TopicName="Yok"} }
                                          : (from t in context.Topics
                                            where (congress.CongressId==t.CongressId)
                                            select new Topic 
                                            {
                                                Id=t.Id,
                                                CongressId=t.CongressId,
                                                Category=t.Category,
                                                TopicName=t.TopicName
                                            }).ToList(),
                                 CongressImages = ((from ci in context.CongressImages
                                                    where (congress.CongressId == ci.CongressId)
                                                    select new CongressImage
                                                    {
                                                        Id = ci.Id,
                                                        CongressId = ci.CongressId,
                                                        Date = ci.Date,
                                                        ImagePath = ci.ImagePath
                                                    }).ToList()).Count == 0
                                                    ? new List<CongressImage> { new CongressImage { Id = -1, CongressId = congress.CongressId, Date = DateTime.Now, ImagePath = "/images/default.jpg" } }
                                                    : (from ci in context.CongressImages
                                                       where (congress.CongressId == ci.CongressId)
                                                       select new CongressImage
                                                       {
                                                           Id = ci.Id,
                                                           CongressId = ci.CongressId,
                                                           Date = ci.Date,
                                                           ImagePath = ci.ImagePath
                                                       }).ToList()
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();

            }
            
           
        }
    }
}
