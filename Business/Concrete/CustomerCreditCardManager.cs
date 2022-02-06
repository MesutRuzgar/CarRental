using Business.Abstract;
using Business.Constants;
using Core.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerCreditCardManager : ICustomerCreditCardService
    {
        ICustomerCreditCardDal _customerCreditCardDal;
       

        public CustomerCreditCardManager(ICustomerCreditCardDal customerCreditCardDal)
        {
            _customerCreditCardDal = customerCreditCardDal;
           
        }

        public IResult DeleteCustomerCreditCard(CustomerCreditCard customerCreditCard)
        {
            _customerCreditCardDal.Delete(customerCreditCard);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CustomerCreditCard>> GetCreditCardsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerCreditCard>>(_customerCreditCardDal.GetAll(ccc=>ccc.CustomerId==customerId));
        }

        public IResult SaveCustomerCreditCard(CustomerCreditCard customerCreditCard)
        {
            var rulesResult = BusinessRules.Run(CheckIfCustomerCreditCardExist(customerCreditCard.CardNumber));
            if (rulesResult != null)
            {
                return rulesResult;
            }
            var saveCustomerCreditCard = new CustomerCreditCard
            {
                CustomerId = customerCreditCard.CustomerId,
                CardHolder = customerCreditCard.CardHolder,
                CardNumber = customerCreditCard.CardNumber,
                Cvv = customerCreditCard.Cvv,
                ExpirationMonth = customerCreditCard.ExpirationMonth,
                ExpirationYear = customerCreditCard.ExpirationYear
            };
            _customerCreditCardDal.Add(saveCustomerCreditCard);
            return new SuccessResult("Kredi Kartınız Başarıyla Kaydedildi.");

        }
        private IResult CheckIfCustomerCreditCardExist(string CardNumber)
        {
            var result = _customerCreditCardDal.GetAll().Any(ccc => ccc.CardNumber == CardNumber);
            if (result)
            {
                return new ErrorResult(Messages.CustomerCreditCardExist);
            }
            return new SuccessResult();
        }
    }
}
