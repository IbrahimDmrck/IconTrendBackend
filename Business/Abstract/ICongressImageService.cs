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
    public interface ICongressImageService
    {
        IDataResult<List<CongressImage>> GetAll();
        IDataResult<List<CongressImage>> GetCongressImage(int congressId);
        IDataResult<CongressImage> GetById(int congressImageId);
        IResult Add(IFormFile file ,int congressId);
        IResult Update(CongressImage congressImage,IFormFile file);
        IResult Delete(CongressImage congress);
        IResult DeleteAllImagesOfCongressByCongressId(int congressId);
    }
}
