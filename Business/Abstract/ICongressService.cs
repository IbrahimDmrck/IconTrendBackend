using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        IDataResult<int> Add(Congress congress);
        IResult Update(Congress congress);
        IResult Delete(Congress congress);
        IDataResult<List<CongressDetailDto>> GetCongressesWithDetails();
        IDataResult<CongressDetailDto> GetCongressDetails(int congressId);
    }
}
