using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaperFileManager : IPaperFileService
    {
        public IResult Add(IFormFile file, int PaperId)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(PaperFile paperFile)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteAllImagesOfCongressByCongressId(int PaperId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<PaperFile>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<PaperFile>> GetPaperImage(int PaperId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(PaperFile paperFile, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
