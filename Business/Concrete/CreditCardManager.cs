using Business.Abstract;
using Business.Constants;
using Core.Entites.Concrete;
using Core.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(),Messages.Listed);
        }


        public IResult GetCheckCreditCard(string cardHolder, string cardNumber, string cvv, string expirationMonth,string expirationYear)
        {
         
            var result = _creditCardDal.GetAll().Any(c => c.CardHolder==cardHolder && c.CardNumber==cardNumber &&c.Cvv==cvv && c.ExpirationMonth == expirationMonth && c.ExpirationYear== expirationYear);            
            if (result==true)
            {
                return new SuccessResult(Messages.CreditCardValidateSuccess);
            }
            else
            {
                return new SuccessResult(Messages.CreditCardNotValidation);
            }
           
         }

        public IDataResult<List<CreditCard>> GetCreditCardByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c=>c.CustomerId==customerId), Messages.Listed);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.Updated);
        }
       
    }
}
