using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFuelTypeService
    {
        IResult Add(FuelType fuelType);
        IResult Delete(FuelType fuelType);
        IResult Update(FuelType fuelType);
        IDataResult<List<FuelType>> GetAll();
    }
}
