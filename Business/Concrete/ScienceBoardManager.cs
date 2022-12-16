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
    public class ScienceBoardManager : IScienceBoardService
    {
        IScienceBoardDal _scienceBoardDal;

        public ScienceBoardManager(IScienceBoardDal scienceBoardDal)
        {
            _scienceBoardDal = scienceBoardDal;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(ScienceBoardValidator))]
        [CacheRemoveAspect("IScienceBoardService.Get")]
        public IResult Add(ScienceBoard scienceBoard)
        {
            var rulesResult = BusinessRules.Run(CheckIfScienceBoardMemberExist(scienceBoard.ScienceBoardMemberName), CheckIfCongressIdExist(scienceBoard.CongressId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            _scienceBoardDal.Add(scienceBoard);
            return new SuccessResult(Messages.ScienceBoardISCreated);
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IScienceBoardService.Get")]
        [CacheRemoveAspect("ICongressService.Get")]
        public IResult Delete(ScienceBoard scienceBoard)
        {
            var rulesResult = BusinessRules.Run(CheckIfScienceBoardMemberIdExist(scienceBoard.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            var deletedScienceBoard = _scienceBoardDal.Get(x=>x.Id==scienceBoard.Id);
            _scienceBoardDal.Delete(deletedScienceBoard);
            return new SuccessResult(Messages.ScienceBoardISDeleted);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(ScienceBoardValidator))]
        [CacheRemoveAspect("IScienceBoardService.Get")]
        [CacheRemoveAspect("ICongressService.Get")]
        public IResult Update(ScienceBoard scienceBoard)
        {
            var rulesResult = BusinessRules.Run(CheckIfScienceBoardMemberIdExist(scienceBoard.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _scienceBoardDal.Update(scienceBoard);
            return new SuccessResult(Messages.ScienceBoardISUpdated);
        }

        [CacheAspect(10)]
        public IDataResult<List<ScienceBoard>> GetAll()
        {
            return new SuccessDataResult<List<ScienceBoard>>(_scienceBoardDal.GetAll(),Messages.ScienceBoardsListed);
        }

        [CacheAspect(10)]
        public IDataResult<ScienceBoard> GetScienceBoardById(int id)
        {
            return new SuccessDataResult<ScienceBoard>(_scienceBoardDal.Get(x=>x.Id==id),Messages.ScienceBoardIsListed);
        }

        //Business Rules

        private IResult CheckIfScienceBoardMemberIdExist(int scienceBoardId)
        {
            var result = _scienceBoardDal.GetAll(x => x.Id == scienceBoardId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.ScienceBoardMemberNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCongressIdExist(int congressId)
        {
            var result = _scienceBoardDal.GetAll(x => x.CongressId == congressId).Any();
            if (result)
            {
                return new ErrorResult(Messages.CongressAlreadyHaveScienceBoard);
            }
            return new SuccessResult();
        }

        private IResult CheckIfScienceBoardMemberExist(string scienceBoardName)
        {
            var result = _scienceBoardDal.GetAll(x => Equals(x.ScienceBoardMemberName, scienceBoardName)).Any();
            if (result)
            {
                return new ErrorResult(Messages.ScienceBoardMemberExist);
            }
            return new SuccessResult();
        }


    }
}
