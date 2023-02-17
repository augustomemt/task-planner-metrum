using System;
using System.Collections.Generic;
using TaskPlannerMetrum.Data.Converter.Implementations;

using TaskPlannerMetrum.Data.VO;
using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Repository.Generic;

namespace TaskPlannerMetrum.Business.Implementations
{
    public class UserBusinessImplementation : IUserBusiness
    {
        private readonly IRepository<User> _repository;

        private readonly UserConverter _converter;

        public UserBusinessImplementation(IRepository<User> repository)
        {
            _repository = repository;
            _converter = new UserConverter();
        }

        // Method responsible for returning all people,
        public List<UserVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Method responsible for returning one person by ID
        public UserVO FindByID(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        // Method responsible to crete one new person
        public UserVO Create(UserVO user)
        {   user.CreationDate = DateTime.Now;
            var userEntity = _converter.Parse(user);
            userEntity = _repository.Create(userEntity);
            return _converter.Parse(userEntity);
        }

        // Method responsible for updating one person
        public UserVO Update(UserVO user)
        {
            var userEntity = _converter.Parse(user);
            userEntity = _repository.Update(userEntity);
            return _converter.Parse(userEntity);
        }

        // Method responsible for deleting a person from an ID
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        UserVO IUserBusiness.FindByID(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
