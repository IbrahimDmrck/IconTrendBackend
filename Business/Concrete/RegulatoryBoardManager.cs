using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        [ValidationAspect(typeof(RegulatoryBoardValidator))]
        [CacheRemoveAspect("IRegulatoryBoardService.Get")]
        public IResult Add(RegulatoryBoard regulatoryBoard)
        {
            var rulesResult = BusinessRules.Run(CheckIfRegulatoryBoardMemberExist(regulatoryBoard.RegulatoryBoardMemberName), CheckIfCongressIdExist(regulatoryBoard.CongressId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            _regulatoryBoardDal.Add(regulatoryBoard);
            return new SuccessResult(Messages.RegulatoryBoardIsCreated);

        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IRegulatoryBoardService.Get")]
        [CacheRemoveAspect("ICongressService.Get")]
        public IResult Delete(RegulatoryBoard regulatoryBoard)
        {
            var rulesResult = BusinessRules.Run(CheckIfRegulatoryBoardMemberIdExist(regulatoryBoard.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            var deletedRegulatoryBorad = _regulatoryBoardDal.Get(x => x.Id == regulatoryBoard.Id);
            _regulatoryBoardDal.Delete(deletedRegulatoryBorad);
            return new SuccessResult(Messages.RegulatoryBoardIsDeleted);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(RegulatoryBoardValidator))]
        [CacheRemoveAspect("IRegulatoryBoardService.Get")]
        [CacheRemoveAspect("ICongressService.Get")]
        public IResult Update(RegulatoryBoard regulatoryBoard)
        {
            var rulesResult = BusinessRules.Run(CheckIfRegulatoryBoardMemberIdExist(regulatoryBoard.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }


            _regulatoryBoardDal.Update(regulatoryBoard);
            return new SuccessResult(Messages.RegulatoryBoardIsUpdated);
        }

        [CacheAspect(10)]
        public IDataResult<List<RegulatoryBoard>> GetAll()
        {
            return new SuccessDataResult<List<RegulatoryBoard>>(_regulatoryBoardDal.GetAll(),Messages.RegulatoryBoardsListed);
        }

        [CacheAspect(10)]
        public IDataResult<RegulatoryBoard> GetRegulatoryBoardById(int id)
        {
            return new SuccessDataResult<RegulatoryBoard>(_regulatoryBoardDal.Get(x=>x.Id==id),Messages.RegulatoryBoardIsListed);
        }

        //Business Rules

        private IResult CheckIfRegulatoryBoardMemberIdExist(int regulatoryBoardId)
        {
            var result = _regulatoryBoardDal.GetAll(x => x.Id == regulatoryBoardId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.RegulatoryBoardMemberNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCongressIdExist(int congressId)
        {
            var result = _regulatoryBoardDal.GetAll(x => x.CongressId == congressId).Any();
            if (result)
            {
                return new ErrorResult(Messages.CongressAlreadyHaveRegulatoryBoard);
            }
            return new SuccessResult();
        }

        private IResult CheckIfRegulatoryBoardMemberExist(string regulatoryBoardName)
        {
            var result = _regulatoryBoardDal.GetAll(x => Equals(x.RegulatoryBoardMemberName, regulatoryBoardName)).Any();
            if (result)
            {
                return new ErrorResult(Messages.RegulatoryBoardMemberExist);
            }
            return new SuccessResult();
        }

    }
}
