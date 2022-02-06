using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCustomerCreditCardDal:EfEntityRepositoryBase<CustomerCreditCard, CarRentalContext>,ICustomerCreditCardDal
    {
       
    }
}
