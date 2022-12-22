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
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CongressManager : ICongressService
    {
        readonly ICongressDal _congressDal;
        readonly ICongressImageService _congressImageService;

        public CongressManager(ICongressDal congressDal, ICongressImageService congressImageService)
        {
            _congressDal = congressDal;
            _congressImageService = congressImageService;
            
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CongressValidator))]
        [CacheRemoveAspect("ICongressService.Get")]
        public IDataResult<int> Add(Congress congress)
        {

             _congressDal.Add(congress);
            var result = _congressDal.Get(x =>
              x.CongressName == congress.CongressName &&
              x.CongressAbout == congress.CongressAbout  &&
              x.CongressAdress == congress.CongressAdress &&
              x.CongressDate==congress.CongressDate &&
              x.CongressPresidentName==congress.CongressPresidentName &&
              x.CongressStatus==congress.CongressStatus &&
              x.RegulatoryBoard==congress.RegulatoryBoard &&
              x.ScienceBoard==congress.ScienceBoard &&
              x.Univercity==congress.Univercity &&
              x.Topic==congress.Topic);
            if (result !=null)
            {
                return new SuccessDataResult<int>(result.CongressId,Messages.CongressAdded);
            }
            return new ErrorDataResult<int>(-1,"Kongre eklenirken bir sorun oluştu");
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ICongressService.Get")]
        public IResult Delete(Congress congress)
        {
            var rulesResult = BusinessRules.Run(CheckIfCongressIdExist(congress.CongressId));
            if (rulesResult !=null)
            {
                return rulesResult;
            }

            var deletedCongress = _congressDal.Get(x => x.CongressId == congress.CongressId);
            _congressImageService.DeleteAllImagesOfCongressByCongressId(deletedCongress.CongressId);
            _congressDal.Delete(deletedCongress);
            return new SuccessResult(Messages.CongressDeleted);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CongressValidator))]
        [CacheRemoveAspect("ICongressService.Get")]
        public IResult Update(Congress congress)
        {
            var rulesResult = BusinessRules.Run(CheckIfCongressIdExist(congress.CongressId));
            if (rulesResult !=null)
            {
                return rulesResult;
            }

            _congressDal.Update(congress);
            return new SuccessResult(Messages.CongressUpdated);
        }

        [CacheAspect(10)]
        public IDataResult<List<Congress>> GetAll()
        {
            return new SuccessDataResult<List<Congress>>(_congressDal.GetAll(), Messages.CongressesListed);
        }

        [CacheAspect(10)]
        public IDataResult<List<CongressDetailDto>> GetCongressesWithDetails()
        {
            return new SuccessDataResult<List<CongressDetailDto>>(_congressDal.GetCongressDetails(), Messages.CongressesListed);
        }

        [CacheAspect(10)]
        public IDataResult<Congress> GetCongressById(int id)
        {
            return new SuccessDataResult<Congress>(_congressDal.Get(x => x.CongressId == id), Messages.CongressIsListed);
        }

        [CacheAspect(10)]
        public IDataResult<CongressDetailDto> GetCongressDetails(int congressId)
        {
            return new SuccessDataResult<CongressDetailDto>(_congressDal.GetCongressDetails(c => c.CongressId == congressId).SingleOrDefault(), Messages.CongressIsListed);
        }

    

        //Business Rules

        private IResult CheckIfCongressIdExist(int congressId)
        {
            var result = _congressDal.GetAll(x=>x.CongressId==congressId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CongressNotExist);
            }
            return new SuccessResult();
        }
    }
}
