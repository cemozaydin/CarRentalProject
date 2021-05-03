using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal 
    {
    //    List<Car> _cars;

    //    public InMemoryCarDal()
    //    {
    //        _cars = new List<Car>
    //       {
    //           new Car{Id=1, BrandId=1,ColorId=1,ModelYear=2019,DailyPrice=245,Description="Audi A3 Otomatik Vites"},
    //           new Car{Id=2, BrandId=1,ColorId=2,ModelYear=2018,DailyPrice=200,Description="Audi A4 Otomatik Vites"},
    //           new Car{Id=3, BrandId=2,ColorId=3,ModelYear=2020,DailyPrice=270,Description="Alfa Romeo Giulietta"},
    //           new Car{Id=4, BrandId=3,ColorId=2,ModelYear=2017,DailyPrice=200,Description="Mercedes GLA 200"},
    //           new Car{Id=5, BrandId=4,ColorId=3,ModelYear=2020,DailyPrice=270,Description="Mazda MX-5"},
    //           new Car{Id=6, BrandId=4,ColorId=1,ModelYear=2018,DailyPrice=300,Description="Mazda 3 Serisi"}
    //       };
    //    }

    //    public void Add(Car car)
    //    {
    //        _cars.Add(car);
    //    }

    //    public void Delete(Car car)
    //    {
    //        Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
    //        _cars.Remove(carToDelete);
    //    }

    //    public Car Get(Expression<Func<Car, bool>> filter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetAll()
    //    {
    //        return _cars;
    //    }

    //    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetById(int brandId)
    //    {
    //        return _cars.Where(c => c.BrandId == brandId).ToList();
    //    }

    //    public List<CarDetailDto> GetCarDetails()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Car car)
    //    {
    //        Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            
    //        carToUpdate.BrandId = car.BrandId;
    //        carToUpdate.ColorId = car.ColorId;
    //        carToUpdate.ModelYear = car.ModelYear;
    //        carToUpdate.DailyPrice = car.DailyPrice;
    //        carToUpdate.Description = car.Description;
    //    }
    //
    }
}
