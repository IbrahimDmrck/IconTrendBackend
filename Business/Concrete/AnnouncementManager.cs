using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Announcement announcement)
        {
            _announcementDal.Add(announcement);
            return new SuccessResult(Messages.Announced);
        }

        public IResult Delete(Announcement announcement)
        {
            _announcementDal.Delete(announcement);
            return new SuccessResult(Messages.AnnounceDeleted);
        }

        public IResult Update(Announcement announcement)
        {
            _announcementDal.Update(announcement);
            return new SuccessResult(Messages.AnnounceUpdated);
        }

        public IDataResult<List<Announcement>> GetAll()
        {
            return new SuccessDataResult<List<Announcement>>(_announcementDal.GetAll(), Messages.AnnouncesListed);
        }

        public IDataResult<Announcement> GetAnnouncementById(int id)
        {
            return new SuccessDataResult<Announcement>(_announcementDal.Get(x => x.Id == id), Messages.AnnounceListed);
        }

       
    }
}
