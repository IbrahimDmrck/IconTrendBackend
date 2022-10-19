using Business.Constants;
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
    public class CongressImageManager : ICongressImage
    {
        ICongressImageDal _congressImageDal;

        public CongressImageManager(ICongressImageDal congressImageDal)
        {
            _congressImageDal = congressImageDal;
        }

        public IResult Add(IFormFile file, int congressId)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CongressImage congress)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteAllImagesOfCongressByCongressId(int congressId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CongressImage>> GetAll()
        {
            return new SuccessDataResult<List<CongressImage>>(_congressImageDal.GetAll(), Messages.CongressImagesListed);
        }

        public IDataResult<CongressImage> GetById(int congressId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CongressImage>> GetCongressImage(int congressId)
        {
            var checkIfCarImage = CheckIfCongressHasImage(congressId);
            var images = checkIfCarImage.Success
                ? checkIfCarImage.Data
                : _congressImageDal.GetAll(c => c.CongressId == congressId);
            return new SuccessDataResult<List<CongressImage>>(images, checkIfCarImage.Message);
        }

        public IResult Update(CongressImage congressImage, IFormFile file)
        {
            throw new NotImplementedException();
        }


        //Business - Rule

        private IDataResult<List<CongressImage>> CheckIfCongressHasImage(int congressId)
        {
            string logoPath = "/images/default.jpg";
            bool result = _congressImageDal.GetAll(c => c.CongressId == congressId).Any();
            if (!result)
            {
                List<CongressImage> imageList = new List<CongressImage>
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
