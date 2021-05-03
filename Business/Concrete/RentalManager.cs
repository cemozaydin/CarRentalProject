using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = CheckReturnDate(rental.CarId);
            
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

           _rentalDal.Add(rental);
           return new SuccessResult(Messages.RentalAdded);

        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetCarRentalDetails(r => r.CarId == carId && r.ReturnDate == null);
            
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        //public IDataResult<Rental> Get(int rentalId)
        //{
        //    return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==rentalId));
        //}

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails()
        {
            Thread.Sleep(1000);
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetCarRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult UpdateReturnDate(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.Id == rental.Id);
            var updateRental = result.LastOrDefault();

            if (updateRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalUpdateReturnDateError);
            }

            updateRental.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(updateRental);
            return new SuccessResult(Messages.RentalUpdateReturnDate);

        }
    }
}
