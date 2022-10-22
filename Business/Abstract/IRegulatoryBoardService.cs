using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRegulatoryBoardService
    {
        IDataResult<RegulatoryBoard> GetRegulatoryBoardById(int id);
        IDataResult<List<RegulatoryBoard>> GetAll();
        IResult Add(RegulatoryBoard regulatoryBoard);
        IResult Update(RegulatoryBoard regulatoryBoard);
        IResult Delete(RegulatoryBoard regulatoryBoard);
    }
}
