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
    public interface IKongreImageService
    {
        IDataResult<List<KongreImage>> GetAll();
        IDataResult<List<KongreImage>> GetKongreImage(int kongreId);
        IDataResult<KongreImage> GetById(int kongreImageId);
        IResult Add(IFormFile file, int kongreId);
        IResult Update(KongreImage kongreImage, IFormFile file);
        IResult Delete(KongreImage kongreImage);
        IResult DeleteAllImagesOfKongreByKongreId(int kongreId);
    }
}
