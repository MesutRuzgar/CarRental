using Business.Abstract;
using Business.Constants;
using Core.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.UserId== userId));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), Messages.Listed);
        }

        public IResult Update(Customer customer)
        {
            var rulesResult = BusinessRules.Run(CheckIfCompanyNameExist(customer.CompanyName));
            if (rulesResult != null)
            {
                return rulesResult;
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckIfCompanyNameExist(string companyName)
        {
            var result = _customerDal.GetAll().Any(c => c.CompanyName == companyName);
            if (result)
            {
                return new ErrorResult(Messages.CompanyExist);
            }
            return new SuccessResult();
        }
    }
}
