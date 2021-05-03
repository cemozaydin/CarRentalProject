
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails(Expression<Func<Rental,bool>> filter=null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from rnt in filter is null ? context.Rentals:context.Rentals.Where(filter)
                             join cr in context.Cars on rnt.CarId equals cr.Id
                             join mdl in context.Models on cr.CarModelId equals mdl.Id
                             join col in context.Colors on mdl.ColorId equals col.Id
                             join brd in context.Brands on mdl.BrandId equals brd.Id
                             join cus in context.Customers on rnt.CustomerId equals cus.Id
                             join usr in context.Users on cus.UserId equals usr.Id
                             select new CarRentalDetailDto
                             {
                                 RentalId = rnt.Id,
                                 CustomerName = usr.FirstName,
                                 CustomerLastName = usr.LastName,
                                 CustomerCompanyName = cus.CompanyName,                                 
                                 ModelName = mdl.ModelName,
                                 BrandName = brd.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = cr.DailyPrice,
                                 RentDate = rnt.RentDate,
                                 ReturnDate = rnt.ReturnDate
                             };

                return result.ToList();
            }           
        }
    }
}
