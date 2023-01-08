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
    public class TrBankAccountInfoManager : ITrBankAccountInfoService
    {
        ITrBankAccountInfoDal _trBankAccountInfoDal;

        public TrBankAccountInfoManager(ITrBankAccountInfoDal trBankAccountInfoDal)
        {
            _trBankAccountInfoDal = trBankAccountInfoDal;
        }

        public IResult Add(TrBankAccountInfo trBank)
        {
            _trBankAccountInfoDal.Add(trBank);
            return new SuccessResult(Messages.TrBankAccountAdded);
        }

        public IResult Delete(TrBankAccountInfo trBank)
        {
            _trBankAccountInfoDal.Delete(trBank);
            return new SuccessResult(Messages.TrBankAccountDeleted);
        }

        public IDataResult<List<TrBankAccountInfo>> GetAll()
        {
            return new SuccessDataResult<List<TrBankAccountInfo>>(_trBankAccountInfoDal.GetAll(), Messages.TrBankAccountsListed);
        }

        public IDataResult<TrBankAccountInfo> GetTrBankAccountInfoById(int id)
        {
            return new SuccessDataResult<TrBankAccountInfo>(_trBankAccountInfoDal.Get(x => x.Id == id), Messages.TrBankAccountBrought);
        }

        public IResult Update(TrBankAccountInfo trBank)
        {
            _trBankAccountInfoDal.Update(trBank);
            return new SuccessResult(Messages.TrBankAccountUpdated);
        }
    }
}
