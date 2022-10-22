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
    public class CongressManager : ICongressService
    {
        ICongressDal _congressDal;

        public CongressManager(ICongressDal congressDal)
        {
            _congressDal = congressDal;
        }

        public IResult Add(CongressPresident congress)
        {
             _congressDal.Add(congress);
            return new SuccessResult(Messages.CongressAdded);
        }

        public IResult Delete(CongressPresident congress)
        {
            _congressDal.Delete(congress);
            return new SuccessResult(Messages.CongressDeleted);
        }

        public IDataResult<List<CongressPresident>> GetAll()
        {
            return new SuccessDataResult<List<CongressPresident>>(_congressDal.GetAll(), Messages.CongressesListed);
        }

        public IDataResult<CongressPresident> GetCongressById(int id)
        {
            return new SuccessDataResult<CongressPresident>(_congressDal.Get(x => x.CongressId == id), Messages.CongressIsListed);
        }

        public IResult Update(CongressPresident congress)
        {
            _congressDal.Update(congress);
            return new SuccessResult(Messages.CongressUpdated);
        }
    }
}
