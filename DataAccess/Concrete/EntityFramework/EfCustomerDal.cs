using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cus in filter is null ? context.Customers : context.Customers.Where(filter)
                             join usr in context.Users on cus.UserId equals usr.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = cus.Id,
                                 UserId = usr.Id,
                                 UserName = usr.FirstName,
                                 UserLastName = usr.LastName,
                                 CompanyName = cus.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
