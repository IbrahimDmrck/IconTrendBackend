using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
    public class TransportlayoverImageManager : ITransportLayoverImageService
    {
        ITransportLayoverImageDal _transportLayoverImageDal;

        public TransportlayoverImageManager(ITransportLayoverImageDal transportLayoverImageDal)
        {
            _transportLayoverImageDal = transportLayoverImageDal;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(TransportLayoverImageValidator))]
        [CacheRemoveAspect("ITransportLayoverImageService.Get")]
        [CacheRemoveAspect("ITransportLayoverService.Get")]
        public IResult Add(IFormFile file, int transportId)
        {

            IResult rulesResult = BusinessRules.Run(CheckIfTransportImageLimitExceeded(transportId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            TransportLayoverImage transportImage = new TransportLayoverImage
            {
                ImagePath = imageResult.Message,
                TransportLayoverId = transportId,
                Date = DateTime.Now
            };

            _transportLayoverImageDal.Add(transportImage);
            return new SuccessResult(Messages.TransportImageIsAdded);
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ITransportLayoverImageService.Get")]
        [CacheRemoveAspect("ITransportLayoverService.Get")]
        public IResult Delete(TransportLayoverImage transport)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfTransportImageIdExist(transport.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deletedImage = _transportLayoverImageDal.Get(x => x.Id == transport.Id);
            var result = FileHelper.Delete(deletedImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorDeleteingImage);
            }
            _transportLayoverImageDal.Delete(deletedImage);
            return new SuccessResult(Messages.TransportImageIsDeleted);
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ITransportLayoverImageService.Get")]
        [CacheRemoveAspect("ITransportLayoverService.Get")]
        public IResult DeleteAllImagesOfTransportByTransportImageId(int tranportId)
        {
            var deletedImages = _transportLayoverImageDal.GetAll(x => x.TransportLayoverId == tranportId);
            if (deletedImages == null)
            {
                return new ErrorResult(Messages.NoPictureOfTheTransport);
            }
            foreach (var deletedImage in deletedImages)
            {
                _transportLayoverImageDal.Delete(deletedImage);
                FileHelper.Delete(deletedImage.ImagePath);

            }
            return new SuccessResult(Messages.TransportImageIsDeleted);
        }

        [SecuredOperation("Admin,User")]
        [CacheAspect(10)]
        public IDataResult<List<TransportLayoverImage>> GetAll()
        {
            return new SuccessDataResult<List<TransportLayoverImage>>(_transportLayoverImageDal.GetAll(), Messages.TransportImagesListed);
        }

        [SecuredOperation("Admin,User")]
        [CacheAspect(10)]
        public IDataResult<TransportLayoverImage> GetById(int transortImageId)
        {
            return new SuccessDataResult<TransportLayoverImage>(_transportLayoverImageDal.Get(x => x.Id == transortImageId), Messages.TransportImageIsListed);
        }

        [SecuredOperation("Admin,User")]
        [CacheAspect(10)]
        public IDataResult<List<TransportLayoverImage>> GetTransportImage(int transportId)
        {
            var checkIfCarImage = CheckIfTransportHasImage(transportId);
            var images = checkIfCarImage.Success
                ? checkIfCarImage.Data
                : _transportLayoverImageDal.GetAll(c => c.TransportLayoverId == transportId);
            return new SuccessDataResult<List<TransportLayoverImage>>(images, checkIfCarImage.Message);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(TransportLayoverImageValidator))]
        [CacheRemoveAspect("ITransportLayoverImageService.Get")]
        [CacheRemoveAspect("ITransportLayoverService.Get")]
        public IResult Update(TransportLayoverImage transportImage, IFormFile file)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfTransportImageIdExist(transportImage.Id), CheckIfTransportImageLimitExceeded(transportImage.TransportLayoverId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var updateImage = _transportLayoverImageDal.Get(x => x.Id == transportImage.Id);
            var result = FileHelper.Update(file, updateImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorUpdateingImage);
            }
            transportImage.ImagePath = result.Message;
            transportImage.Date = DateTime.Now;
            _transportLayoverImageDal.Update(transportImage);
            return new SuccessResult(Messages.TransportImageIsUpdate);
        }

        // Business - Rules

        private IResult CheckIfTransportImageLimitExceeded(int transportId)
        {
            int result = _transportLayoverImageDal.GetAll(c => c.TransportLayoverId == transportId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.TransportImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfTransportImageIdExist(int imageId)
        {
            var result = _transportLayoverImageDal.GetAll(c => c.Id == imageId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.TransportImageIdNotExist);
            }
            return new SuccessResult();
        }

        private IDataResult<List<TransportLayoverImage>> CheckIfTransportHasImage(int transportId)
        {
            string logoPath = "/images/default.jpg";
            bool result = _transportLayoverImageDal.GetAll(c => c.TransportLayoverId == transportId).Any();
            if (!result)
            {
                List<TransportLayoverImage> imageList = new List<TransportLayoverImage>
                {
                    new TransportLayoverImage
                    {
                       ImagePath=logoPath,
                       TransportLayoverId=transportId,
                       Date=DateTime.Now
                    }
                };
                return new SuccessDataResult<List<TransportLayoverImage>>(imageList, Messages.GetDefaultImage);

            }
            return new ErrorDataResult<List<TransportLayoverImage>>(new List<TransportLayoverImage>(), Messages.TransportImagesListed);
        }
    }
}


