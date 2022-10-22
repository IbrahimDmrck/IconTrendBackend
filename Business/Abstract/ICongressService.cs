using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICongressService
    {
        IDataResult<CongressPresident> GetCongressById(int id);
        IDataResult<List<CongressPresident>> GetAll();
        IResult Add(CongressPresident congress);
        IResult Update(CongressPresident congress);
        IResult Delete(CongressPresident congress);
    }
}
