using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGeneralInformationService
    {
        IDataResult<GeneralInformation> GetGeneralInfoById(int id);
        IDataResult<List<GeneralInformation>> GetAll();
        IResult Add(GeneralInformation generalInformation);
        IResult Update(GeneralInformation generalInformation);
        IResult Delete(GeneralInformation generalInformation);
    }
}
