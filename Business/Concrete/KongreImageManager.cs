using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.Filehelper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class KongreImageManager : IKongreImageService
    {
        IKongreImageDal _kongreImageDal;

        public KongreImageManager(IKongreImageDal kongreImageDal)
        {
            _kongreImageDal = kongreImageDal;
        }

        public IResult Add(IFormFile file, int kongreId)
        {
           IResult rulesResult=BusinessRules.Run(CheckIfKongreImageLimitExceeded(kongreId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            KongreImage kongreImage = new()
            {
                ImagePath = imageResult.Message,
                KongreId = kongreId,
                Date = DateTime.Now
            };

            _kongreImageDal.Add(kongreImage);
            return new SuccessResult(Messages.AnnounceImageIsAdded);
        }

        public IResult Delete(KongreImage kongreImage)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfKongreImageIdExist(kongreImage.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deleteImage = _kongreImageDal.Get(x => x.Id == kongreImage.Id);
            var result = FileHelper.Delete(deleteImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorDeleteingImage);
            }

            _kongreImageDal.Delete(deleteImage);
            return new SuccessResult(Messages.AnnounceImageIsDeleted);
        }

        public IResult DeleteAllImagesOfKongreByKongreId(int kongreId)
        {
            var deletedImages = _kongreImageDal.GetAll(x => x.KongreId == kongreId);
            if (deletedImages == null)
            {
                return new ErrorResult(Messages.NoPictureOfTheAnnounce);
            }
            foreach (var deletedImage in deletedImages)
            {
                _kongreImageDal.Delete(deletedImage);
                FileHelper.Delete(deletedImage.ImagePath);
            }
            return new SuccessResult(Messages.AnnounceImageIsDeleted);
        }

        public IDataResult<List<KongreImage>> GetAll()
        {
            return new SuccessDataResult<List<KongreImage>>(_kongreImageDal.GetAll(), Messages.AnnounceImagesListed);
        }

        public IDataResult<KongreImage> GetById(int kongreImageId)
        {
            return new SuccessDataResult<KongreImage>(_kongreImageDal.Get(x => x.Id == kongreImageId), Messages.AnnounceImageIsListed);
        }

        public IDataResult<List<KongreImage>> GetKongreImage(int kongreId)
        {
            var checkIfKongreImage = CheckIfKongreHasImage(kongreId);
            var images = checkIfKongreImage.Success
                ? checkIfKongreImage.Data
                : _kongreImageDal.GetAll(x => x.KongreId == kongreId);
            return new SuccessDataResult<List<KongreImage>>(images, checkIfKongreImage.Message);
        }

        public IResult Update(KongreImage kongreImage, IFormFile file)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfKongreImageIdExist(kongreImage.Id), CheckIfKongreImageLimitExceeded(kongreImage.KongreId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var updateImage = _kongreImageDal.Get(x => x.Id == kongreImage.Id);
            var result = FileHelper.Update(file, updateImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorUpdateingImage);
            }
            kongreImage.ImagePath = result.Message;
            kongreImage.Date = DateTime.Now;
            _kongreImageDal.Update(kongreImage);
            return new SuccessResult(Messages.AnnounceImageIsUpdate);
        }

        //Business Rules

        private IResult CheckIfKongreImageLimitExceeded(int kongreId)
        {
            var result = _kongreImageDal.GetAll(x => x.KongreId == kongreId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.AnnounceImageLimitExceeded);
            }
            return new SuccessResult();
        }


        private IDataResult<List<KongreImage>> CheckIfKongreHasImage(int kongreId)
        {
            string logoPath = "/images/default.jpg";
            bool result = _kongreImageDal.GetAll(x => x.KongreId == kongreId).Any();
            if (!result)
            {
                List<KongreImage> imageList = new()
                {
                    new KongreImage
                    {
                        ImagePath = logoPath,
                         KongreId= kongreId,
                        Date = DateTime.Now
                    }
                };
                return new SuccessDataResult<List<KongreImage>>(imageList, Messages.GetDefaultImage);
            }
            return new ErrorDataResult<List<KongreImage>>(new List<KongreImage>(), Messages.AnnounceImagesListed);
        }

        private IResult CheckIfKongreImageIdExist(int imageId)
        {
            var result = _kongreImageDal.GetAll(x => x.Id == imageId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.AnnounceImageIdNotExist);
            }
            return new SuccessResult();
        }
    }
}
