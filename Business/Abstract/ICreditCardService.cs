using Core.Entites.Concrete;
using Core.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCardDetailDto>> GetCarDetails();
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<List<CreditCard>> GetCreditCardByUserId(int userId);
        IDataResult<CreditCard> GetUserFindeksScore(int userId);
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IDataResult<bool> GetCheckCreditCard(string cardHolder,string cardNumber,string cvv, string expirationMonth, string expirationYear);
    }
}
