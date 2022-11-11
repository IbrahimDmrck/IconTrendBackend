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

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(TopicValidator))]
        [CacheRemoveAspect("ITopicService.Get")]
        public IResult Add(Topic topic)
        {
            var rulesResult = BusinessRules.Run(CheckIfTopicExist(topic.TopicName));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _topicDal.Add(topic);
            return new SuccessResult(Messages.TopicIsAdded);
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ITopicService.Get")]
        [CacheRemoveAspect("ICongressService.Get")]
        public IResult Delete(Topic topic)
        {
            var rulesResult = BusinessRules.Run(CheckIfTopicIdExist(topic.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            var deletedTopic = _topicDal.Get(x=>x.Id==topic.Id);
            _topicDal.Delete(deletedTopic);
            return new SuccessResult(Messages.TopicIsDeleted);
        }

        [CacheAspect(10)]
        public IDataResult<List<Topic>> GetAll()
        {
            return new SuccessDataResult<List<Topic>>(_topicDal.GetAll(), Messages.TopicsListed);
        }

        [CacheAspect(10)]
        public IDataResult<Topic> GetTopicById(int id)
        {
            return new SuccessDataResult<Topic>(_topicDal.Get(x => x.Id == id), Messages.TopicIsListed);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(TopicValidator))]
        [CacheRemoveAspect("ITopicService.Get")]
        [CacheRemoveAspect("ICongressService.Get")]
        public IResult Update(Topic topic)
        {
            var rulesResult = BusinessRules.Run(CheckIfTopicIdExist(topic.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _topicDal.Update(topic);
            return new SuccessResult(Messages.TopicIsUpdated);
        }

        //Business Rules

        private IResult CheckIfTopicIdExist(int topicId)
        {
            var result = _topicDal.GetAll(x => x.Id == topicId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.TopicNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfTopicExist(string topicName)
        {
            var result = _topicDal.GetAll(x => Equals(x.TopicName, topicName)).Any();
            if (result)
            {
                return new ErrorResult(Messages.TopicNameExist);
            }
            return new SuccessResult();
        }

    }
}
