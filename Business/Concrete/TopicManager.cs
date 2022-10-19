using Business.Abstract;
using Business.Constants;
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
    public class TopicManager : ITopicService
    {
        ITopicDal _topicDal;

        public TopicManager(ITopicDal topicDal)
        {
            _topicDal = topicDal;
        }

        public IResult Add(Topic topic)
        {
            _topicDal.Add(topic);
            return new SuccessResult(Messages.TopicIsAdded);
        }

        public IResult Delete(Topic topic)
        {
            _topicDal.Delete(topic);
            return new SuccessResult(Messages.TopicIsDeleted);
        }

        public IDataResult<List<Topic>> GetAll()
        {
            return new SuccessDataResult<List<Topic>>(_topicDal.GetAll(), Messages.TopicsListed);
        }

        public IDataResult<Topic> GetTopicById(int id)
        {
            return new SuccessDataResult<Topic>(_topicDal.Get(x => x.TopicId == id), Messages.TopicIsListed);
        }

        public IResult Update(Topic topic)
        {
            _topicDal.Update(topic);
            return new SuccessResult(Messages.TopicIsUpdated);
        }
    }
}
