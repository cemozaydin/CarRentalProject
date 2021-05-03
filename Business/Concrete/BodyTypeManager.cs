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
    public class BodyTypeManager : IBodyTypeService
    {
        IBodyTypeDal _bodyTypeDal;

        public BodyTypeManager(IBodyTypeDal bodyTypeDal)
        {
            _bodyTypeDal = bodyTypeDal;
        }

        public IResult Add(BodyType bodyType)
        {
            _bodyTypeDal.Add(bodyType);
            return new SuccessResult(Messages.BodyTypeAdded);
        }

        public IResult Delete(BodyType bodyType)
        {
            _bodyTypeDal.Delete(bodyType);
            return new SuccessResult(Messages.BodyTypeDeleted);
        }

        public IDataResult<List<BodyType>> GetAll()
        {
            return new SuccessDataResult<List<BodyType>>(_bodyTypeDal.GetAll(), Messages.BodyTypeListed);
        }

        public IResult Update(BodyType bodyType)
        {
            _bodyTypeDal.Update(bodyType);
            return new SuccessResult(Messages.BodyTypeUpdated);
        }
    }
}
