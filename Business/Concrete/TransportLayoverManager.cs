﻿using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TransportLayoverManager : ITransportLayoverService
    {
        public IResult Add(TransportLayover transportLayover)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(TransportLayover transportLayover)
        {
            throw new NotImplementedException();
        }

        public IDataResult<TransportLayover> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<TransportLayover> GetTransportLayoverById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(TransportLayover transportLayover)
        {
            throw new NotImplementedException();
        }
    }
}
