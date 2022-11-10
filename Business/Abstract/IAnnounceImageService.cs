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
    public interface IAnnounceImageService
    {
        IDataResult<List<AnnounceImage>> GetAll();
        IDataResult<List<AnnounceImage>> GetAnnounceImage(int announceId);
        IDataResult<AnnounceImage> GetById(int announceImageId);
        IResult Add(IFormFile file, int announceId);
        IResult Update(AnnounceImage announceImage, IFormFile file);
        IResult Delete(AnnounceImage announceImage);
        IResult DeleteAllImagesOfAnnounceByAnnounceId(int announceId);
    }
}
