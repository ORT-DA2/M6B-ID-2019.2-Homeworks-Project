using System;
using Homeworks.Domain;
using Homeworks.BusinessLogic.Interface;
using Homeworks.DataAccess.Interface;
using System.Collections.Generic;

namespace Homeworks.BusinessLogic
{
    public class UserLogic : ILogic<User>
    {
        private IRepository<User> repository;
        public UserLogic(IRepository<User> repository) {
            this.repository = repository;
        }
        public User Create(User entity)
        {
            repository.Add(entity);
            repository.Save();
            return entity;
        }

        public User Get(Guid id)
        {
            return repository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }

        public void Remove(Guid id)
        {
            User user = repository.Get(id);
            ThrowErrorIfItsInvalid(user);
            repository.Remove(user);
            repository.Save();
        }

        public User Update(Guid id, User entity)
        {
            User user = repository.Get(id);
            ThrowErrorIfItsInvalid(user);
            user.Update(entity);
            repository.Update(user);
            repository.Save();
            return user;
        }
        private void ThrowErrorIfItsInvalid(User user) 
        {
            if (user == null || !user.IsValid()) 
            {
                throw new ArgumentException("Lanza error por que es invaldia la entity");
            }
        }
    }
}
