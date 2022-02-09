using Business.Abstract;
using Business.Constants;
using Core.Entites.Concrete;
using Core.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
   public class UserManager:IUserService
    {
        IUserDal _userDal;
        
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
               

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User user)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserDetailExist(user.Email,user.FirstName,user.LastName));
            if (rulesResult != null)
            {
                return rulesResult;
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        private IResult CheckIfUserDetailExist(string email,string firstName,string LastName )
        {
            var result = _userDal.GetAll().Any(u=> u.Email==email && u.FirstName==firstName && u.LastName==LastName);
            if (result)
            {
                return new ErrorResult(Messages.UserDetailExist);
            }
            return new SuccessResult();
        }

    }
}
