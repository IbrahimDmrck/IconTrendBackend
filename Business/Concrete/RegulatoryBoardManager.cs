using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class RegulatoryBoardManager : IRegulatoryBoardService
    {
        IRegulatoryBoardDal _regulatoryBoardDal;

        public RegulatoryBoardManager(IRegulatoryBoardDal regulatoryBoardDal)
        {
            _regulatoryBoardDal = regulatoryBoardDal;
        }

        [SecuredOperation("Admin")]
        public IResult Add(RegulatoryBoard regulatoryBoard)
        {
            _regulatoryBoardDal.Add(regulatoryBoard);
            return new SuccessResult(Messages.RegulatoryBoardIsCreated);

        }

        [SecuredOperation("Admin")]
        public IResult Delete(RegulatoryBoard regulatoryBoard)
        {
            _regulatoryBoardDal.Delete(regulatoryBoard);
            return new SuccessResult(Messages.RegulatoryBoardIsDeleted);
        }

        [SecuredOperation("Admin")]
        public IResult Update(RegulatoryBoard regulatoryBoard)
        {
            _regulatoryBoardDal.Update(regulatoryBoard);
            return new SuccessResult(Messages.RegulatoryBoardIsUpdated);
        }

        public IDataResult<List<RegulatoryBoard>> GetAll()
        {
            return new SuccessDataResult<List<RegulatoryBoard>>(_regulatoryBoardDal.GetAll(),Messages.RegulatoryBoardsListed);
        }

        public IDataResult<RegulatoryBoard> GetRegulatoryBoardById(int id)
        {
            return new SuccessDataResult<RegulatoryBoard>(_regulatoryBoardDal.Get(x=>x.Id==id),Messages.RegulatoryBoardIsListed);
        }

     
    }
}
