using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IScienceBoardService
    {
        IDataResult<ScienceBoard> GetScienceBoardById(int id);
        IDataResult<List<ScienceBoard>> GetAll();
        IResult Add(ScienceBoard scienceBoard);
        IResult Update(ScienceBoard scienceBoard);
        IResult Delete(ScienceBoard scienceBoard);
    }
}
