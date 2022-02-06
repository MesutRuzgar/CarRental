using Core.Entites.Concrete;
using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerCreditCardService
    {
        IDataResult<List<CustomerCreditCard>> GetCreditCardsByCustomerId(int customerId);
        IResult SaveCustomerCreditCard(CustomerCreditCard customerCreditCard);
        IResult DeleteCustomerCreditCard(CustomerCreditCard customerCreditCard);
    }
}
