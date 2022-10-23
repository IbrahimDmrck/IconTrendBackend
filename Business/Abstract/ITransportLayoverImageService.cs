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
    public interface ITransportLayoverImageService
    {
        IDataResult<List<TransportLayoverImage>> GetAll();
        IDataResult<List<TransportLayoverImage>> GetTransportImage(int transportId);
        IDataResult<TransportLayoverImage> GetById(int transortImageId);
        IResult Add(IFormFile file, int transportId);
        IResult Update(TransportLayoverImage transportImage, IFormFile file);
        IResult Delete(TransportLayoverImage transport);
        IResult DeleteAllImagesOfTransportByTransportImageId(int tranportId);
    }
}
