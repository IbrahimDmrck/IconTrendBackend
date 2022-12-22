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
    public interface IKongreService
    {
        IDataResult<Kongre> GetKongreById(int id);
        IDataResult<List<Kongre>> GetAll();
        IDataResult<int> Add(Kongre kongre);
        IResult Update(Kongre kongre);
        IResult Delete(Kongre kongre);
        IDataResult<List<KongreDetailDto>> GetKongreWithDetails();
        IDataResult<KongreDetailDto> GetKongreDetails(int kongreId);
    }
}
