using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        IResult IRepositoryService<User>.Add(User entity)
        {
            throw new NotImplementedException();
        }
        public IResult Update(User entity)
        {
            throw new NotImplementedException();
        }
        public IResult Delete(User entity)
        {
            throw new NotImplementedException();
        }
        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
        public IDataResult<User> Get(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
