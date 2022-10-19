using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaperService
    {
        IDataResult<Paper> GetPaperById(int id);
        IDataResult<List<Paper>> GetAll();
        IResult Add(Paper paper);
        IResult Update(Paper paper);
        IResult Delete(Paper paper);
    }
}
