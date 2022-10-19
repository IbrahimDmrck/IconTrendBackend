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
    public class TopicManager : ITopicService
    {
        public IResult Add(Topic topic)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Topic topic)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Topic> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Topic> GetTopicById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}
