﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ScienceBoardManager : IScienceBoardService
    {
        IScienceBoardDal _scienceBoardDal;

        public ScienceBoardManager(IScienceBoardDal scienceBoardDal)
        {
            _scienceBoardDal = scienceBoardDal;
        }

        [SecuredOperation("Admin")]
        public IResult Add(ScienceBoard scienceBoard)
        {
            _scienceBoardDal.Add(scienceBoard);
            return new SuccessResult(Messages.ScienceBoardISCreated);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(ScienceBoard scienceBoard)
        {
            _scienceBoardDal.Delete(scienceBoard);
            return new SuccessResult(Messages.ScienceBoardISDeleted);
        }

        [SecuredOperation("Admin")]
        public IResult Update(ScienceBoard scienceBoard)
        {
            _scienceBoardDal.Update(scienceBoard);
            return new SuccessResult(Messages.ScienceBoardISUpdated);
        }

        [CacheAspect(10)]
        public IDataResult<List<ScienceBoard>> GetAll()
        {
            return new SuccessDataResult<List<ScienceBoard>>(_scienceBoardDal.GetAll(),Messages.ScienceBoardsListed);
        }

        [CacheAspect(10)]
        public IDataResult<ScienceBoard> GetScienceBoardById(int id)
        {
            return new SuccessDataResult<ScienceBoard>(_scienceBoardDal.Get(x=>x.Id==id),Messages.ScienceBoardIsListed);
        }

     
    }
}
