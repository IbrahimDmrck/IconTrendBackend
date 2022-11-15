using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        ITransportLayoverImageService _transportLayoverImageService;

        public TransportLayoverManager(ITransportLayoverDal transportLayoverDal, ITransportLayoverImageService transportLayoverImageService)
        {
            _transportLayoverDal = transportLayoverDal;
            _transportLayoverImageService = transportLayoverImageService;

        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(TransportLayoverValidator))]
        [CacheRemoveAspect("ITransportLayoverService.Get")]
        public IDataResult<int> Add(TransportLayover transportLayover)
        {
            
            _transportLayoverDal.Add(transportLayover);
            var result = _transportLayoverDal.Get(x =>
            x.Description==transportLayover.Description &&
            x.Capacity==transportLayover.Capacity &&
            x.MinDemand==transportLayover.MinDemand &&
            x.Price==transportLayover.Price 
            );
            if (result !=null)
            {
                return new SuccessDataResult<int>(result.TransportId, Messages.TransportLayoverIsAdded);
            }
            return new ErrorDataResult<int>(-1,"Ulaşım ve konaklama bilgisi eklenirken bir sorun oluştu");
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ITransportLayoverService.Get")]
        public IResult Delete(TransportLayover transportLayover)
        {
            var rulesResult = BusinessRules.Run(CheckIfTransportLayoverIdExist(transportLayover.TransportId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            var deletedTransport = _transportLayoverDal.Get(x=>x.TransportId==transportLayover.TransportId);
            _transportLayoverImageService.DeleteAllImagesOfTransportByTransportImageId(deletedTransport.TransportId);
            _transportLayoverDal.Delete(deletedTransport);
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
        [ValidationAspect(typeof(TransportLayoverValidator))]
        [CacheRemoveAspect("ITransportLayoverService.Get")]
        public IResult Update(TransportLayover transportLayover)
        {
            var rulesResult = BusinessRules.Run(CheckIfTransportLayoverIdExist(transportLayover.TransportId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _transportLayoverDal.Update(transportLayover);
            return new SuccessResult(Messages.TransportLayoverIsUpdated);
        }


        //Business Rules

        private IResult CheckIfTransportLayoverIdExist(int transportId)
        {
            var result = _transportLayoverDal.GetAll(x => x.TransportId == transportId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.TransportLayoverNotExist);
            }
            return new SuccessResult();
        }
    }
}
