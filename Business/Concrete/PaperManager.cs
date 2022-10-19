using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
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
        IPaperDal _paperDal;

        public PaperManager(IPaperDal paperDal)
        {
            _paperDal = paperDal;
        }

        public IResult Add(Paper paper)
        {
            _paperDal.Add(paper);
            return new SuccessResult(Messages.PaperIsAdded);
        }

        public IResult Delete(Paper paper)
        {
            _paperDal.Delete(paper);
            return new SuccessResult(Messages.PaperIsDeleted);
        }

        public IDataResult<List<Paper>> GetAll()
        {
            return new SuccessDataResult<List<Paper>>(_paperDal.GetAll(), Messages.PapersListed);
        }

        public IDataResult<Paper> GetPaperById(int id)
        {
            return new SuccessDataResult<Paper>(_paperDal.Get(x => x.PaperId == id), Messages.PaperIsListed);
        }

        public IResult Update(Paper paper)
        {
            _paperDal.Update(paper);
            return new SuccessResult(Messages.PaperIsUpdated);
        }
    }
}
