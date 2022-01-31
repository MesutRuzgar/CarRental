using Core.Entites.Concrete;
using Core.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<List<CreditCard>> GetCreditCardByCustomerId(int customerId);
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IResult GetCheckCreditCard(string cardHolder,string cardNumber,string cvv, string expirationMonth, string expirationYear);
    }
}
