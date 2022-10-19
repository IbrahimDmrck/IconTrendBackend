﻿using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnnouncementService
    {
        IDataResult<Announcement> GetAnnouncementById(int id);
        IDataResult<List<Announcement>> GetAll();
        IResult Add(Announcement announcement);
        IResult Update(Announcement announcement);
        IResult Delete(Announcement announcement);
    }
}
