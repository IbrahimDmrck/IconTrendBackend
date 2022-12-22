using Business.Abstract;
using Business.Constants;
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
    public class KongreManager : IKongreService
    {
        IKongreDal _kongreDal;
        IKongreImageService _kongreImageService;

        public KongreManager(IKongreDal kongreDal, IKongreImageService kongreImageService)
        {
            _kongreDal = kongreDal;
            _kongreImageService = kongreImageService;
        }

        public IDataResult<int> Add(Kongre kongre)
        {
            _kongreDal.Add(kongre);

            var result = _kongreDal.Get(x=>
            x.KongreAdi==kongre.KongreAdi &&
            x.KongreBaskani==kongre.KongreBaskani &&
            x.KongreDuzenlemeKurulu==kongre.KongreDuzenlemeKurulu &&
            x.KongreHakkinda==kongre.KongreHakkinda &&
            x.KongreKonusu==kongre.KongreKonusu &&
            x.KongreTarihi==kongre.KongreTarihi &&
            x.BilimKurulu==kongre.BilimKurulu &&
            x.KongreAdresi==kongre.KongreAdresi);
            if (result!=null)
            {
                return new SuccessDataResult<int>(result.KongreId, Messages.CongressAdded);
            }
            return new ErrorDataResult<int>(-1,"Kongre eklenirken bir hata oluştu");
        }

        public IResult Delete(Kongre kongre)
        {
            var rulesResult = BusinessRules.Run(CheckIfKongreIdExist(kongre.KongreId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deletedKongre = _kongreDal.Get(x => x.KongreId == kongre.KongreId);
            _kongreImageService.DeleteAllImagesOfKongreByKongreId(deletedKongre.KongreId);
            _kongreDal.Delete(deletedKongre);
            return new SuccessResult(Messages.AnnounceDeleted);
        }

        public IDataResult<List<Kongre>> GetAll()
        {
            return new SuccessDataResult<List<Kongre>>(_kongreDal.GetAll(), Messages.AnnouncesListed);
        }

        public IDataResult<Kongre> GetKongreById(int id)
        {
            return new SuccessDataResult<Kongre>(_kongreDal.Get(x => x.KongreId == id), Messages.AnnouncementListed);
        }

        public IDataResult<KongreDetailDto> GetKongreDetails(int kongreId)
        {
            return new SuccessDataResult<KongreDetailDto>(_kongreDal.GetKongreDetails(x => x.KongreId == kongreId).SingleOrDefault(), Messages.AnnouncementListed);
        }

        public IDataResult<List<KongreDetailDto>> GetKongreWithDetails()
        {
            return new SuccessDataResult<List<KongreDetailDto>>(_kongreDal.GetKongreDetails(), Messages.AnnouncesListed);
        }

        public IResult Update(Kongre kongre)
        {
            throw new NotImplementedException();
        }

        //Business Rules
        private IResult CheckIfKongreIdExist(int kongreId)
        {
            var result = _kongreDal.GetAll(x => x.KongreId == kongreId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.AnnounceNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfKongreAdı(string kongreAdi)
        {
            var result = _kongreDal.GetAll(x => x.KongreAdi == kongreAdi).Any();
            if (result)
            {
                return new ErrorResult(Messages.AnnounceExist);
            }
            return new SuccessResult();
        }
    }
}
