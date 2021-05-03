using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        //IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        //IDataResult<List<Car>> GetCarsByColorId(int colorId);       
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId); //sonradan yazıldı
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId); //sonradan yazıldı

        IResult AddTransactionalTest(Car car);
    }
}
