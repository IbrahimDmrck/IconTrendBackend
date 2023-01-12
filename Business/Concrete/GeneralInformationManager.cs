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
    public class GeneralInformationManager : IGeneralInformationService
    {
        IGeneralInformationDal _generalInformationDal;

        public GeneralInformationManager(IGeneralInformationDal generalInformationDal)
        {
            _generalInformationDal = generalInformationDal;
        }

        public IResult Add(GeneralInformation generalInformation)
        {
            _generalInformationDal.Add(generalInformation);
            return new SuccessResult(Messages.GeneralInformationAdd);
        }

        public IResult Delete(GeneralInformation generalInformation)
        {
            _generalInformationDal.Delete(generalInformation);
            return new SuccessResult(Messages.GeneralInformationDelete);
        }

        public IDataResult<List<GeneralInformation>> GetAll()
        {
            return new SuccessDataResult<List<GeneralInformation>>(_generalInformationDal.GetAll(), Messages.GeneralInformationsListed);
        }

        public IDataResult<GeneralInformation> GetGeneralInfoById(int id)
        {
            return new SuccessDataResult<GeneralInformation>(_generalInformationDal.Get(x=>x.Id==id), Messages.GeneralInformationListed);
        }

        public IResult Update(GeneralInformation generalInformation)
        {
            _generalInformationDal.Update(generalInformation);
            return new SuccessResult(Messages.GeneralInformationUpdate);
        }
    }
}
