using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICongressPresidentService
    {
        IDataResult<CongressPresident> GetCongressPresidentById(int id);
        IDataResult<List<CongressPresident>> GetAll();
        IResult Add(CongressPresident congressPresident);
        IResult Update(CongressPresident congressPresident);
        IResult Delete(CongressPresident congressPresident);
    }
}
