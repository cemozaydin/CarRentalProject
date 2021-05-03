using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBodyTypeService
    {
        IResult Add(BodyType bodyType);
        IResult Delete(BodyType bodyType);
        IResult Update(BodyType bodyType);
        IDataResult<List<BodyType>> GetAll();
    }
}
