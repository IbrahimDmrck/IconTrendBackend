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
    public class AnnounceImageManager:IAnnounceImageService
    {
        readonly IAnnounceImageDal _announceImageDal;

        public AnnounceImageManager(IAnnounceImageDal announceImageDal)
        {
            _announceImageDal = announceImageDal;
        }

        public IResult Add(IFormFile file, int announceId)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfAnnounceImageLimitExceeded(announceId));
            if (rulesResult !=null)
            {
                return rulesResult;
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            AnnounceImage announceImage = new()
            {
                ImagePath = imageResult.Message,
                AnnounceId = announceId,
                Date = DateTime.Now
            };

            _announceImageDal.Add(announceImage);
            return new SuccessResult(Messages.AnnounceImageIsAdded);
        }

        public IResult Delete(AnnounceImage announceImage)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfAnnounceImageIdExist(announceImage.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            var deleteImage = _announceImageDal.Get(x => x.Id == announceImage.Id);
            var result = FileHelper.Delete(deleteImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorDeleteingImage);
            }

            _announceImageDal.Delete(deleteImage);
            return new SuccessResult(Messages.AnnounceImageIsDeleted);
        }

        public IResult DeleteAllImagesOfAnnounceByAnnounceId(int announceId)
        {
            var deletedImages = _announceImageDal.GetAll(x => x.AnnounceId == announceId);
            if (deletedImages==null)
            {
                return new ErrorResult(Messages.NoPictureOfTheAnnounce);
            }
            foreach (var deletedImage in deletedImages)
            {
                _announceImageDal.Delete(deletedImage);
                FileHelper.Delete(deletedImage.ImagePath);
            }
            return new SuccessResult(Messages.AnnounceImageIsDeleted);
        }

        public IDataResult<List<AnnounceImage>> GetAll()
        {
            return new SuccessDataResult<List<AnnounceImage>>(_announceImageDal.GetAll(),Messages.AnnounceImagesListed);
        }

        public IDataResult<List<AnnounceImage>> GetAnnounceImage(int announceId)
        {
            var checkIfAnnounceImage = CheckIfAnnounceHasImage(announceId);
            var images = checkIfAnnounceImage.Success
                ? checkIfAnnounceImage.Data
                : _announceImageDal.GetAll(x => x.AnnounceId == announceId);
            return new SuccessDataResult<List<AnnounceImage>>(images, checkIfAnnounceImage.Message);
        }

        public IDataResult<AnnounceImage> GetById(int announceImageId)
        {
            return new SuccessDataResult<AnnounceImage>(_announceImageDal.Get(x=>x.Id==announceImageId),Messages.AnnounceImageIsListed);
        }

        public IResult Update(AnnounceImage announceImage, IFormFile file)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfAnnounceImageIdExist(announceImage.Id), CheckIfAnnounceImageLimitExceeded(announceImage.AnnounceId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            var updateImage = _announceImageDal.Get(x => x.Id == announceImage.Id);
            var result = FileHelper.Update(file, updateImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorUpdateingImage);
            }
            announceImage.ImagePath = result.Message;
            announceImage.Date = DateTime.Now;
            _announceImageDal.Update(announceImage);
            return new SuccessResult(Messages.AnnounceImageIsUpdate);
        }

        //Business Rules

        private IResult CheckIfAnnounceImageLimitExceeded(int announceId)
        {
            var result = _announceImageDal.GetAll(x=>x.AnnounceId==announceId).Count;
            if (result>=10)
            {
                return new ErrorResult(Messages.AnnounceImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfAnnounceImageIdExist(int imageId)
        {
            var result = _announceImageDal.GetAll(x=>x.Id==imageId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.AnnounceImageIdNotExist);
            }
            return new SuccessResult();
        }

        private IDataResult<List<AnnounceImage>> CheckIfAnnounceHasImage(int announceId)
        {
            string logoPath = "/images/default.jpg";
            bool result = _announceImageDal.GetAll(x=>x.AnnounceId==announceId).Any();
            if (!result)
            {
                List<AnnounceImage> imageList = new()
                {
                    new AnnounceImage
                    {
                        ImagePath=logoPath,
                        AnnounceId=announceId,
                        Date=DateTime.Now
                    }
                };
                return new SuccessDataResult<List<AnnounceImage>>(imageList,Messages.GetDefaultImage);
            }
            return new ErrorDataResult<List<AnnounceImage>>(new List<AnnounceImage>(), Messages.AnnounceImagesListed);
        }
    }
}
