using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Castle.Core.Internal;
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
    public class RentalManager : IRentalService
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
                if (item.ReturnDate == null)
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
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
          

        }



        public IDataResult<bool> GetCheckRentDate(int carId, DateTime rentDate, DateTime? returnDate)
        {
            List<DateTime> kullaniciTarihAraliklari = new List<DateTime>();
            List<DateTime> dbTarihAraliklari = new List<DateTime>();
            List<RentalDetailDto> rentalDetail = _rentalDal.GetCheckRentDate(carId, rentDate, returnDate);
            bool varMi = false;
            if (returnDate != null && returnDate > rentDate)
            {
                kullaniciTarihAraliklari = ikiTarihAralikHesaplama(returnDate, rentDate);
            }
            foreach (var item in rentalDetail)
            {
                if (item.ReturnDate != null && item.ReturnDate > item.RentDate)
                {
                    dbTarihAraliklari = ikiTarihAralikHesaplama(item.ReturnDate.Value.Date, item.RentDate.Date);
                }
            }
            foreach (var item in kullaniciTarihAraliklari)
            {
                if (dbTarihAraliklari.Contains(item))
                {
                    varMi = true;
                }
            }
            return new SuccessDataResult<bool>(varMi);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalUserDetails(int userId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(c=>c.UserId== userId));
        }

        public IDataResult<decimal> TotalEarnings()
        {
          

            return new SuccessDataResult<decimal>(_rentalDal.TotalEarnings());
        }

        private List<DateTime> ikiTarihAralikHesaplama(DateTime? returnDate, DateTime rentDate)
        {
            List<DateTime> kullaniciTarihAraliklari = new List<DateTime>();
            TimeSpan ts = (System.DateTime)returnDate.Value.Date - rentDate.Date;

            for (int i = 0; i < ts.Days; i++)
            {
                kullaniciTarihAraliklari.Add(rentDate.AddDays(i));
            }
            return kullaniciTarihAraliklari;
        }
    }
}
