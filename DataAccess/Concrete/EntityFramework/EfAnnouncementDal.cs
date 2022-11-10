
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
    public class EfAnnouncementDal : EfEntityRepositoryBase<Announcement, IconTrendContext>, IAnnouncementDal
    {
        public List<AnnouncementDetailDto> GetAnnouncementDetails(Expression<Func<AnnouncementDetailDto, bool>> filter = null)
        {
            using (var context = new IconTrendContext())
            {
                var result = from announce in context.Announcements

                             select new AnnouncementDetailDto
                             {
                                 Id = announce.Id,
                                 AnnounceContent = announce.AnnounceContent,
                                 AnnounceDate = announce.AnnounceDate,
                                 AnnounceTitle = announce.AnnounceTitle,
                                 AnnounceStatus = announce.AnnounceStatus,
                                 AnnounceImages = ((from announceImg in context.AnnounceImages
                                                    where (announce.Id == announceImg.AnnounceId)
                                                    select new AnnounceImage
                                                    {
                                                        Id = announceImg.Id,
                                                        AnnounceId = announceImg.AnnounceId,
                                                        Date = announceImg.Date,
                                                        ImagePath = announceImg.ImagePath

                                                    }).ToList()).Count == 0
                                                 ? new List<AnnounceImage> { new AnnounceImage { Id = -1, AnnounceId = announce.Id, Date = DateTime.Now, ImagePath = "/images/default.jpg" } }
                                                 : (from announceImg in context.AnnounceImages
                                                    where (announce.Id == announceImg.AnnounceId)
                                                    select new AnnounceImage
                                                    {
                                                        Id = announceImg.Id,
                                                        AnnounceId = announceImg.AnnounceId,
                                                        Date = announceImg.Date,
                                                        ImagePath = announceImg.ImagePath
                                                    }).ToList()
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
