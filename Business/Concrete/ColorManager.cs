using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessDataResult<Color>(Messages.ColorAdded);
            //Console.WriteLine("\nRenk başarıyla veritabanına eklendi.");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessDataResult<Color>(Messages.ColorDeleted);
            //Console.WriteLine("\nRenk başarıyla veritabanından silindi.");
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessDataResult<Color>(Messages.ColorUpdate);
            //Console.WriteLine("\nRenk başarıyla güncellendi.");
        }
    }
}
