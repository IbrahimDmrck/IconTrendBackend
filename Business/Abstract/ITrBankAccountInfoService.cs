using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITrBankAccountInfoService
    {
        IDataResult<TrBankAccountInfo> GetTrBankAccountInfoById(int id);
        IDataResult<List<TrBankAccountInfo>> GetAll();
        IResult Add(TrBankAccountInfo trBank);
        IResult Update(TrBankAccountInfo trBank);
        IResult Delete(TrBankAccountInfo trBank);
    }
}
