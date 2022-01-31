using Core.DataAccess;
using Core.Entites.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICreditCardDal: IEntityRepository<CreditCard>
    {
        public List<CreditCardDto> GetCreditCardDetails();
    }
}
