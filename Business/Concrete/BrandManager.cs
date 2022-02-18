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
   public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(Brand brand)
        {
            var rulesResult= BusinessRules.Run(CheckIfBrandNameExist(brand.BrandName));
            if (rulesResult != null)
            {
                return rulesResult;
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);


        }

        [SecuredOperation("admin")]
        public IResult Delete(Brand brand)
        {
            
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }
        [CacheRemoveAspect("IBrandService.GetAll")]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Listed);
        }
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId));
            
        }

        [SecuredOperation("admin")]
        public IResult Update(Brand brand)
        {
            var rulesResult = BusinessRules.Run(CheckIfBrandNameExist(brand.BrandName),
                CheckIfBrandIdExist(brand.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfBrandNameExist(string brandName)
        {
            var result = _brandDal.GetAll().Any(b => b.BrandName == brandName);
            if (result)
            {
                return new ErrorResult(Messages.BrandExist);
            }
            return new SuccessResult();
        }
        private IResult CheckIfBrandIdExist(int brandId)
        {
            var result = _brandDal.GetAll().Any(b => b.Id == brandId);
            if (!result)
            {
                return new ErrorResult(Messages.BrandNotExist);
            }
            return new SuccessResult();
        }
    }
}
