using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
        public IResult Add(CongressPresident congressPresident)
        {
            _congressPresidentDal.Add(congressPresident);
            return new SuccessResult(Messages.CongressPresidentIsAdded);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(CongressPresident congressPresident)
        {
            _congressPresidentDal.Delete(congressPresident);
            return new SuccessResult(Messages.CongressPresidentIsDeleted);
        }

        [SecuredOperation("Admin")]
        public IResult Update(CongressPresident congressPresident)
        {
            _congressPresidentDal.Add(congressPresident);
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

        
    }
}
