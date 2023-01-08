using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBankAccountInfoService
    {
        IDataResult<BankAccountInfo> GetBankAccountInfoById(int id);
        IDataResult<List<BankAccountInfo>> GetAll();
        IResult Add(BankAccountInfo accountInfo);
        IResult Update(BankAccountInfo accountInfo);
        IResult Delete(BankAccountInfo accountInfo);
    }
}
