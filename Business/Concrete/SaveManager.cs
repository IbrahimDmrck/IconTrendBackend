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
    public class SaveManager : ISaveService
    {
        ISaveDal _saveDal;

        public SaveManager(ISaveDal saveDal)
        {
            _saveDal = saveDal;
        }

        public IResult Add(Save save)
        {
            _saveDal.Add(save);
            return new SuccessResult(Messages.SaveAdded);
        }

        public IResult Delete(Save save)
        {
            _saveDal.Delete(save);
            return new SuccessResult(Messages.SaveDeleted);
        }

        public IDataResult<List<Save>> GetAll()
        {
            return new SuccessDataResult<List<Save>>(_saveDal.GetAll(),Messages.SavesListed);
        }

        public IDataResult<Save> GetSaveById(int id)
        {
            return new SuccessDataResult<Save>(_saveDal.Get(x => x.Id == id), Messages.SaveBrought);
        }

        public IResult Update(Save save)
        {
            _saveDal.Update(save);
            return new SuccessResult(Messages.SaveUpdated);
        }
    }
}
