using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class GearTypeManager : IGearTypeService
    {
        IGearTypeDal _gearTypeDal;

        public GearTypeManager(IGearTypeDal gearTypeDal)
        {
            _gearTypeDal = gearTypeDal;
        }

        public IResult Add(GearType gearType)
        {
            _gearTypeDal.Add(gearType);
            return new SuccessResult(Messages.GearTypeAdded);
        }

        public IResult Delete(GearType gearType)
        {
            _gearTypeDal.Delete(gearType);
            return new SuccessResult(Messages.GearTypeDeleted);
        }

        public IDataResult<List<GearType>> GetAll()
        {
            return new SuccessDataResult<List<GearType>>(_gearTypeDal.GetAll(),Messages.GearTypeListed);
        }

        public IResult Update(GearType gearType)
        {
            _gearTypeDal.Update(gearType);
            return new SuccessResult(Messages.GearTypeUpdated);
        }
    }
}
