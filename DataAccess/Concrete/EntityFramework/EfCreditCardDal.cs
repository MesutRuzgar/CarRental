using Core.DataAccess.EntityFramework;
using Core.Entites.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, CarRentalContext>, ICreditCardDal
    {
       
       
        public List<CreditCardDetailDto> GetCreditCardDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cc in context.CreditCards
                             join u in context.Users on cc.UserId equals u.Id
                             select new CreditCardDetailDto
                             {
                                 Id = cc.Id,
                                 UserId = cc.UserId,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CardHolder = cc.CardHolder,
                                 CardNumber = cc.CardNumber,
                                 Cvv = cc.Cvv,
                                 ExpirationMonth = cc.ExpirationMonth,
                                 ExpirationYear = cc.ExpirationYear
                             };
                return result.ToList();
            }

        }
    }
}
