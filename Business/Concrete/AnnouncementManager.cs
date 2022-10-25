using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

       
        [SecuredOperation("Admin")]
        public IResult Add(Announcement announcement)
        {
            _announcementDal.Add(announcement);
            return new SuccessResult(Messages.Announced);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(Announcement announcement)
        {
            _announcementDal.Delete(announcement);
            return new SuccessResult(Messages.AnnounceDeleted);
        }

        [SecuredOperation("Admin")]
        public IResult Update(Announcement announcement)
        {
            _announcementDal.Update(announcement);
            return new SuccessResult(Messages.AnnounceUpdated);
        }

        [CacheAspect(10)]
        public IDataResult<List<Announcement>> GetAll()
        {
            return new SuccessDataResult<List<Announcement>>(_announcementDal.GetAll(), Messages.AnnouncesListed);
        }

        [CacheAspect(10)]
        public IDataResult<Announcement> GetAnnouncementById(int id)
        {
            return new SuccessDataResult<Announcement>(_announcementDal.Get(x => x.Id == id), Messages.AnnouncementListed);
        }

       
    }
}
