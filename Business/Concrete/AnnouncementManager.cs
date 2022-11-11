using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        IAnnounceImageService _announceImageService;

        public AnnouncementManager(IAnnouncementDal announcementDal, IAnnounceImageService announceImageService)
        {
            _announcementDal = announcementDal;
            _announceImageService = announceImageService;
        }

       
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(AnnounceValidator))]
        [CacheRemoveAspect("IAnnounceService.Get")]
        public IDataResult<int> Add(Announcement announcement)
        {
            _announcementDal.Add(announcement);

            var result = _announcementDal.Get(x =>
              x.AnnounceTitle == announcement.AnnounceTitle &&
              x.AnnounceContent == announcement.AnnounceContent &&
              x.AnnounceDate == announcement.AnnounceDate &&
              x.AnnounceStatus == announcement.AnnounceStatus
            );
            if (result!=null)
            {
                return new SuccessDataResult<int>(result.Id,Messages.Announced);
            }
            return new ErrorDataResult<int>(-1,"Duyuru eklenirken bir hata oluştu");
           
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IAnnounceService.Get")]
        [CacheRemoveAspect("IAnnounceImageService.Get")]
        public IResult Delete(Announcement announcement)
        {
            var rulesResult = BusinessRules.Run(CheckIfAnnounceIdExist(announcement.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            var deletedAnnounce = _announcementDal.Get(x=>x.Id==announcement.Id);
            _announceImageService.DeleteAllImagesOfAnnounceByAnnounceId(deletedAnnounce.Id);
            _announcementDal.Delete(deletedAnnounce);
            return new SuccessResult(Messages.AnnounceDeleted);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(AnnounceValidator))]
        [CacheRemoveAspect("IAnnounceService.Get")]
        [CacheRemoveAspect("IAnnounceImageService.Get")]
        public IResult Update(Announcement announcement)
        {
            var rulesResult = BusinessRules.Run(CheckIfAnnounceIdExist(announcement.Id),CheckIfAnnounceTitle(announcement.AnnounceTitle));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

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

        public IDataResult<List<AnnouncementDetailDto>> GetAnnouncementsWithDetails()
        {
            return new SuccessDataResult<List<AnnouncementDetailDto>>(_announcementDal.GetAnnouncementDetails(), Messages.AnnouncesListed);
        }

        public IDataResult<AnnouncementDetailDto> GetAnnounceDetails(int announceId)
        {
            return new SuccessDataResult<AnnouncementDetailDto>(_announcementDal.GetAnnouncementDetails(x => x.Id == announceId).SingleOrDefault(), Messages.AnnouncementListed);
        }
        //Business Rules

        private IResult CheckIfAnnounceIdExist(int announceId)
        {
            var result = _announcementDal.GetAll(x => x.Id == announceId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.AnnounceNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfAnnounceTitle(string announceTitle)
        {
            var result = _announcementDal.GetAll(x => x.AnnounceTitle == announceTitle).Any();
            if (result)
            {
                return new ErrorResult(Messages.AnnounceExist);
            }
            return new SuccessResult();
        }
    }
}
