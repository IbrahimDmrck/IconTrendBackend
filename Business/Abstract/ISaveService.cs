using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISaveService
    {
        IDataResult<Save> GetSaveById(int id);
        IDataResult<List<Save>> GetAll();
        IResult Add(Save save);
        IResult Update(Save save);
        IResult Delete(Save save);
    }
}
