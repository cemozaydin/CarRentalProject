using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IGearTypeService
    {
        IResult Add(GearType gearType);
        IResult Delete(GearType gearType);
        IResult Update(GearType gearType);
        IDataResult<List<GearType>> GetAll();
    }
}
