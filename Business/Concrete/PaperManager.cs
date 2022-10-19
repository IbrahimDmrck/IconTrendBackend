using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaperManager : IPaperService
    {
        public IResult Add(Paper paper)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Paper paper)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Paper> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Paper> GetPaperById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Paper paper)
        {
            throw new NotImplementedException();
        }
    }
}
