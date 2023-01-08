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
    public class BankAccountInfoManager : IBankAccountInfoService
    {
        IBankAccountInfoDal _bankAccountInfo;

        public BankAccountInfoManager(IBankAccountInfoDal bankAccountInfo)
        {
            _bankAccountInfo = bankAccountInfo;
        }

        public IResult Add(BankAccountInfo accountInfo)
        {
            _bankAccountInfo.Add(accountInfo);
            return new SuccessResult(Messages.BankAccountAdded);
        }

        public IResult Delete(BankAccountInfo accountInfo)
        {
            _bankAccountInfo.Delete(accountInfo);
            return new SuccessResult(Messages.BankAccountDeleted);
        }

        public IDataResult<List<BankAccountInfo>> GetAll()
        {
            return new SuccessDataResult<List<BankAccountInfo>>(_bankAccountInfo.GetAll(), Messages.BankAccountsListed);
        }

        public IDataResult<BankAccountInfo> GetBankAccountInfoById(int id)
        {
            return new SuccessDataResult<BankAccountInfo>(_bankAccountInfo.Get(x=>x.Id==id), Messages.BankAccountBrought);
        }

        public IResult Update(BankAccountInfo accountInfo)
        {
            _bankAccountInfo.Update(accountInfo);
            return new SuccessResult(Messages.BankAccountUpdated);
        }
    }
}
