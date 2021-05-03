using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                //var result = from cr in context.Cars
                //             join b in context.Brands on cr.BrandId equals b.Id
                //             join cl in context.Colors on cr.ColorId equals cl.Id
                //             select new CarDetailDto 
                //             { 
                //                 CarId = cr.Id, 
                //                 CarName = cr.Description, 
                //                 BrandName = b.BrandName, 
                //                 ColorName = cl.ColorName, 
                //                 DailyPrice = cr.DailyPrice 
                //             };


                var result = from cr in context.Cars
                             join mdl in context.Models on cr.CarModelId equals mdl.Id
                             join brn in context.Brands on mdl.BrandId equals brn.Id
                             join clr in context.Colors on mdl.ColorId equals clr.Id
                             join btyp in context.BodyTypes on mdl.BodyTypeId equals btyp.Id
                             join ftyp in context.FuelTypes on mdl.FuelTypeId equals ftyp.Id
                             join gtyp in context.GearTypes on mdl.GearTypeId equals gtyp.Id
                             select new CarDetailDto
                             {
                                 CarId = cr.Id,
                                 BrandName = brn.BrandName,
                                 BrandId = mdl.BrandId,
                                 ModelName = mdl.ModelName,
                                 ColorName = clr.ColorName,
                                 ColorId = mdl.ColorId,
                                 ModelYear = mdl.ModelYear,
                                 BodyTypeName = btyp.BodyTypeName,
                                 FuelTypeName = ftyp.FuelTypeName,
                                 GearTypeName = gtyp.GearTypeName,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join mdl in context.Models on cr.CarModelId equals mdl.Id
                             join brn in context.Brands on mdl.BrandId equals brn.Id
                             join clr in context.Colors on mdl.ColorId equals clr.Id
                             join btyp in context.BodyTypes on mdl.BodyTypeId equals btyp.Id
                             join ftyp in context.FuelTypes on mdl.FuelTypeId equals ftyp.Id
                             join gtyp in context.GearTypes on mdl.GearTypeId equals gtyp.Id
                             where mdl.BrandId == brandId
                             select new CarDetailDto
                             {
                                 CarId = cr.Id,
                                 BrandId = mdl.BrandId,
                                 ColorId = mdl.ColorId,
                                 BrandName = brn.BrandName,
                                 ModelName = mdl.ModelName,
                                 ColorName = clr.ColorName,
                                 ModelYear = mdl.ModelYear,
                                 BodyTypeName = btyp.BodyTypeName,
                                 FuelTypeName = ftyp.FuelTypeName,
                                 GearTypeName = gtyp.GearTypeName,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join mdl in context.Models on cr.CarModelId equals mdl.Id
                             join brn in context.Brands on mdl.BrandId equals brn.Id
                             join clr in context.Colors on mdl.ColorId equals clr.Id
                             join btyp in context.BodyTypes on mdl.BodyTypeId equals btyp.Id
                             join ftyp in context.FuelTypes on mdl.FuelTypeId equals ftyp.Id
                             join gtyp in context.GearTypes on mdl.GearTypeId equals gtyp.Id
                             where mdl.ColorId == colorId
                             select new CarDetailDto
                             {
                                 CarId = cr.Id,
                                 BrandName = brn.BrandName,
                                 BrandId = mdl.BrandId,
                                 ColorId = mdl.ColorId,
                                 ModelName = mdl.ModelName,
                                 ColorName = clr.ColorName,
                                 ModelYear = mdl.ModelYear,
                                 BodyTypeName = btyp.BodyTypeName,
                                 FuelTypeName = ftyp.FuelTypeName,
                                 GearTypeName = gtyp.GearTypeName,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description
                             };
                return result.ToList();
            }
        }
    } 
}