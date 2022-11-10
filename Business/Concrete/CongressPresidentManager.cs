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
    public class CongressPresidentManager : ICongressPresidentService
    {
        ICongressPresidentDal _congressPresidentDal;

        public CongressPresidentManager(ICongressPresidentDal congressPresidentDal)
        {
            _congressPresidentDal = congressPresidentDal;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CongressPresidentValidator))]
        [CacheRemoveAspect("ICongressPresidentService.Get")]
        public IResult Add(CongressPresident congressPresident)
        {
            var rulesResult = BusinessRules.Run(CheckIfCongressPresidentNameExist(congressPresident.CongressPresidentName));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            _congressPresidentDal.Add(congressPresident);
            return new SuccessResult(Messages.CongressPresidentIsAdded);
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ICongressPresidentService.Get")]
        [CacheRemoveAspect("ICongressService.Get")]
        public IResult Delete(CongressPresident congressPresident)
        {
            var rulesResult = BusinessRules.Run(CheckIfCongressPresidentIdExist(congressPresident.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            var deletePresident = _congressPresidentDal.Get(x=>x.Id==congressPresident.Id);
            _congressPresidentDal.Delete(deletePresident);
            return new SuccessResult(Messages.CongressPresidentIsDeleted);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CongressPresidentValidator))]
        [CacheRemoveAspect("ICongressPresidentService.Get")]
        [CacheRemoveAspect("ICongressService.Get")]
        public IResult Update(CongressPresident congressPresident)
        {
            var rulesResult = BusinessRules.Run(CheckIfCongressPresidentNameExist(congressPresident.CongressPresidentName),CheckIfCongressPresidentIdExist(congressPresident.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            _congressPresidentDal.Update(congressPresident);
            return new SuccessResult(Messages.CongressPresidentIsUpdated);
        }

        [CacheAspect(10)]
        public IDataResult<List<CongressPresident>> GetAll()
        {
            return new SuccessDataResult<List<CongressPresident>>(_congressPresidentDal.GetAll(),Messages.CongressPresidentsListed);
        }

        [CacheAspect(10)]
        public IDataResult<CongressPresident> GetCongressPresidentById(int id)
        {
            return new SuccessDataResult<CongressPresident>(_congressPresidentDal.Get(x=>x.Id==id),Messages.CongressPresidentIsListed);
        }

        //Business Rules
        
        private IResult CheckIfCongressPresidentIdExist(int congressPresidentId)
        {
            var result = _congressPresidentDal.GetAll(x => x.Id == congressPresidentId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CongressPresidentNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCongressPresidentNameExist(string congressPresidentName)
        {
            var result = _congressPresidentDal.GetAll(x =>x.CongressPresidentName== congressPresidentName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CongressPresidentExist);
            }
            return new SuccessResult();
        }
    }
}
