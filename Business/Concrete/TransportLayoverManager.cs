using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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

        [SecuredOperation("Admin")]
        public IResult Add(TransportLayover transportLayover)
        {
            _transportLayoverDal.Add(transportLayover);
            return new SuccessResult(Messages.TransportLayoverIsAdded);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(TransportLayover transportLayover)
        {
            _transportLayoverDal.Delete(transportLayover);
            return new SuccessResult(Messages.TransportLayoverIsDeleted);
        }

        [CacheAspect(10)]
        public IDataResult<List<TransportLayover>> GetAll()
        {
            return new SuccessDataResult<List<TransportLayover>>(_transportLayoverDal.GetAll(), Messages.TransportLayoversListed);
        }

        [CacheAspect(10)]
        public IDataResult<TransportLayoverDetailDto> GetTransportDetails(int transportId)
        {
            return new SuccessDataResult<TransportLayoverDetailDto>(_transportLayoverDal.GetTransportDetails(c => c.TransportId == transportId).SingleOrDefault(), Messages.TransportIsListed);
        }

        [SecuredOperation("Admin")]
        [CacheAspect(10)]
        public IDataResult<TransportLayover> GetTransportLayoverById(int id)
        {
            return new SuccessDataResult<TransportLayover>(_transportLayoverDal.Get(x => x.TransportId == id), Messages.TransportLayoverIsListed);
        }

        [SecuredOperation("Admin")]
        public IResult Update(TransportLayover transportLayover)
        {
            _transportLayoverDal.Update(transportLayover);
            return new SuccessResult(Messages.TransportLayoverIsUpdated);
        }
    }
}
