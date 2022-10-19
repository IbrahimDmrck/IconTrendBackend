
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITopicService
    {
        IDataResult<Topic> GetTopicById(int id);
        IDataResult<Topic> GetAll();
        IResult Add(Topic topic);
        IResult Update(Topic topic);
        IResult Delete(Topic topic);
    }
}
