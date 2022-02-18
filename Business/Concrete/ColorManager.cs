using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [SecuredOperation("admin")]
        public IResult Add(Color color)
        {
            var rulesResult = BusinessRules.Run(CheckIfColorNameExist(color.ColorName));
            if (rulesResult != null)
            {
                return rulesResult;
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Color color)
        {            
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheRemoveAspect("IColorService.GetAll")]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.Listed);
        }

        [CacheRemoveAspect("IColorService.Get")]
        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId));
        }

        [SecuredOperation("admin")]
        public IResult Update(Color color)
        {
            var rulesResult = BusinessRules.Run(CheckIfColorNameExist(color.ColorName),
                 CheckIfColorIdExist(color.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfColorNameExist(string colorName)
        {
            var result = _colorDal.GetAll().Any(c => c.ColorName == colorName);
            if (result)
            {
                return new ErrorResult(Messages.ColorExist);
            }
            return new SuccessResult();
        }
        private IResult CheckIfColorIdExist(int colorId)
        {
            var result = _colorDal.GetAll().Any(c => c.Id == colorId);
            if (!result)
            {
                return new ErrorResult(Messages.ColorNotExist);
            }
            return new SuccessResult();
        }
    }
}
