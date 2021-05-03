using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            if (user.FirstName=="" || user.LastName=="")
            {
                return new ErrorResult(Messages.FirstNameLastNameInvalid);
            }

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);

        }

        public IResult Delete(User user)
        {
            if (user.Id != 0)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            else
            {
                return new ErrorResult(Messages.UserNotDeleted);
            }

        }

        public IDataResult<List<User>> GetAll()
        {            
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
