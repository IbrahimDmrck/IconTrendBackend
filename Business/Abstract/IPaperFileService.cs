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
    public interface IPaperFileService
    {
        IDataResult<List<PaperFile>> GetAll();
        IDataResult<List<PaperFile>> GetPaperImage(int PaperId);
        IResult Add(IFormFile file, int PaperId);
        IResult Update(PaperFile paperFile, IFormFile file);
        IResult Delete(PaperFile paperFile);
        IResult DeleteAllImagesOfCongressByCongressId(int PaperId);
    }
}
