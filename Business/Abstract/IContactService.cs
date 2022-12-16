using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        IDataResult<Contact> GetContactById(int id);
        IDataResult<List<Contact>> GetAll();
        IResult Add(Contact contact);
        IResult Update(Contact contact);
        IResult Delete(Contact contact);
    }
}
