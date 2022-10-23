using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TransportLayoverManager : ITransportLayoverService
    {
        ITransportLayoverDal _transportLayoverDal;

        public TransportLayoverManager(ITransportLayoverDal transportLayoverDal)
        {
            _transportLayoverDal = transportLayoverDal;
        }

        public IResult Add(TransportLayover transportLayover)
        {
            _transportLayoverDal.Add(transportLayover);
            return new SuccessResult(Messages.TransportLayoverIsAdded);
        }

        public IResult Delete(TransportLayover transportLayover)
        {
            _transportLayoverDal.Delete(transportLayover);
            return new SuccessResult(Messages.TransportLayoverIsDeleted);
        }

        public IDataResult<List<TransportLayover>> GetAll()
        {
            return new SuccessDataResult<List<TransportLayover>>(_transportLayoverDal.GetAll(), Messages.TransportLayoversListed);
        }

        public IDataResult<TransportLayoverDetailDto> GetTransportDetails(int transportId)
        {
            return new SuccessDataResult<TransportLayoverDetailDto>(_transportLayoverDal.GetTransportDetails(c => c.TransportId == transportId).SingleOrDefault(), Messages.TransportIsListed);
        }

        public IDataResult<TransportLayover> GetTransportLayoverById(int id)
        {
            return new SuccessDataResult<TransportLayover>(_transportLayoverDal.Get(x => x.TransportId == id), Messages.TransportLayoverIsListed);
        }

        public IResult Update(TransportLayover transportLayover)
        {
            _transportLayoverDal.Update(transportLayover);
            return new SuccessResult(Messages.TransportLayoverIsUpdated);
        }
    }
}
