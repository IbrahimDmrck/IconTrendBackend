using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CongressManager : ICongressService
    {
        public IResult Add(Congress congress)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Congress congress)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Congress> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Congress> GetBrandById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Congress congress)
        {
            throw new NotImplementedException();
        }
    }
}
