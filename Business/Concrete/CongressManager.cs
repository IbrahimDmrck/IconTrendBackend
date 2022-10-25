using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
        ICongressDal _congressDal;

        public CongressManager(ICongressDal congressDal)
        {
            _congressDal = congressDal;
        }

        [SecuredOperation("Admin")]
        public IResult Add(Congress congress)
        {
             _congressDal.Add(congress);
            return new SuccessResult(Messages.CongressAdded);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(Congress congress)
        {
            _congressDal.Delete(congress);
            return new SuccessResult(Messages.CongressDeleted);
        }

        [CacheAspect(10)]
        public IDataResult<List<Congress>> GetAll()
        {
            return new SuccessDataResult<List<Congress>>(_congressDal.GetAll(), Messages.CongressesListed);
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

        [SecuredOperation("Admin")]
        public IResult Update(Congress congress)
        {
            _congressDal.Update(congress);
            return new SuccessResult(Messages.CongressUpdated);
        }
    }
}
