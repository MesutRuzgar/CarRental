using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
  public  class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

   
        public IResult Add(Rental rental)
        {
            List<RentalDetailDto> rentalDetail = _rentalDal.GetRentalDetails().Where(x => x.CarId == rental.CarId).ToList();
            bool isCarReturned = true;
            foreach (var item in rentalDetail)
            {
                if (item.ReturnDate==null)
                {
                    isCarReturned = false;
                }
            }
            if (isCarReturned)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Succecss);
            }
            else
            {
                return new SuccessResult("Araç Kirada. Teslim Edilmeden Kiralanamaz");
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.Listed);
        }
    }
}
