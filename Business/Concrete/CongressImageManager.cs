using Core.Utilities.Result.Abstract;
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
            throw new NotImplementedException();
        }

        public IDataResult<List<CongressImage>> GetCongressImage(int congressId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CongressImage congressImage, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
