using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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

namespace Business.Abstract
{
    public class CongressImageManager : ICongressImageService
    {
        readonly ICongressImageDal _congressImageDal;

        public CongressImageManager(ICongressImageDal congressImageDal)
        {
            _congressImageDal = congressImageDal;
        }

        [SecuredOperation("Admin")]
        public IResult Add(IFormFile file, int congressId)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfCongressImageLimitExceeded(congressId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            CongressImage congressImage = new()
            {
                ImagePath=imageResult.Message,
                CongressId=congressId,
                Date=DateTime.Now
            };

            _congressImageDal.Add(congressImage);
            return new SuccessResult(Messages.CongressImageIsAdded);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(CongressImage congress)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfCongressImageIdExist(congress.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deletedImage = _congressImageDal.Get(x=>x.Id==congress.Id);
            var result = FileHelper.Delete(deletedImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorDeleteingImage);
            }
            _congressImageDal.Delete(deletedImage);
            return new SuccessResult(Messages.CongressImageIsDeleted);
        }

        [SecuredOperation("Admin")]
        public IResult DeleteAllImagesOfCongressByCongressId(int congressId)
        {
            var deletedImages = _congressImageDal.GetAll(x=>x.CongressId==congressId);
            if (deletedImages==null)
            {
                return new ErrorResult(Messages.NoPictureOfTheCongress);
            }
            foreach (var deletedImage in deletedImages)
            {
                _congressImageDal.Delete(deletedImage);
                FileHelper.Delete(deletedImage.ImagePath);

            }
            return new SuccessResult(Messages.CongressImageIsDeleted);
        }

        [CacheAspect(10)]
        public IDataResult<List<CongressImage>> GetAll()
        {
            return new SuccessDataResult<List<CongressImage>>(_congressImageDal.GetAll(), Messages.CongressImagesListed);
        }

        //[SecuredOperation("Admin")]
        [CacheAspect(10)]
        public IDataResult<CongressImage> GetById(int congressImageId)
        {
            return new SuccessDataResult<CongressImage>(_congressImageDal.Get(x=>x.Id==congressImageId),Messages.CongressImageIsListed);
        }

        //[SecuredOperation("Admin")]
        [CacheAspect(10)]
        public IDataResult<List<CongressImage>> GetCongressImage(int congressId)
        {
            var checkIfCongressImage = CheckIfCongressHasImage(congressId);
            var images = checkIfCongressImage.Success
                ? checkIfCongressImage.Data
                : _congressImageDal.GetAll(c => c.CongressId == congressId);
            return new SuccessDataResult<List<CongressImage>>(images, checkIfCongressImage.Message);
        }

        [SecuredOperation("Admin")]
        public IResult Update(CongressImage congressImage, IFormFile file)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfCongressImageIdExist(congressImage.Id), CheckIfCongressImageLimitExceeded(congressImage.CongressId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var updateImage = _congressImageDal.Get(x=>x.Id==congressImage.Id);
            var result = FileHelper.Update(file,updateImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorUpdateingImage);
            }
            congressImage.ImagePath = result.Message;
            congressImage.Date = DateTime.Now;
            _congressImageDal.Update(congressImage);
            return new SuccessResult(Messages.CongressImageIsUpdate);

        }


        //Business - Rule

        private IResult CheckIfCongressImageLimitExceeded(int congressId)
        {
            int result = _congressImageDal.GetAll(c => c.CongressId == congressId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CongressImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCongressImageIdExist(int imageId)
        {
            var result = _congressImageDal.GetAll(c => c.Id == imageId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CongressImageIdNotExist);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CongressImage>> CheckIfCongressHasImage(int congressId)
        {
            string logoPath = "/images/default.jpg";
            bool result = _congressImageDal.GetAll(c => c.CongressId == congressId).Any();
            if (!result)
            {
                List<CongressImage> imageList = new()
                {
                    new CongressImage
                    {
                       ImagePath=logoPath,
                       CongressId=congressId,
                       Date=DateTime.Now
                    }
                };
                return new SuccessDataResult<List<CongressImage>>(imageList, Messages.GetDefaultImage);

            }
            return new ErrorDataResult<List<CongressImage>>(new List<CongressImage>(), Messages.CongressImagesListed);
        }
    }
}
