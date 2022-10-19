using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransportLayoverService
    {
        IDataResult<TransportLayover> GetTransportLayoverById(int id);
        IDataResult<TransportLayover> GetAll();
        IResult Add(TransportLayover transportLayover);
        IResult Update(TransportLayover transportLayover);
        IResult Delete(TransportLayover transportLayover);
    }
}
