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
        IDataResult<Congress> GetCongressById(int id);
        IDataResult<List<Congress>> GetAll();
        IResult Add(Congress congress);
        IResult Update(Congress congress);
        IResult Delete(Congress congress);
    }
}
