using System;
using Homeworks.Domain;
using Homeworks.BusinessLogic.Interface;
using Homeworks.DataAccess.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Homeworks.BusinessLogic
{
    public class SessionsLogic : ISession<UserSession>
    {
        private IRepository<UserSession> repository;
        private IRepository<User> userRepository;
        public SessionsLogic(IRepository<UserSession> repository, IRepository<User> userRepository) {
            this.repository = repository;
            this.userRepository = userRepository;
        }

        public IEnumerable<UserSession> GetAll()
        {
            return repository.GetAll();
        }

        public bool IsAdmin(Guid token)
        {
            return repository.Get(token).IsAdmin;
        }

        public bool isLogued(Guid token)
        {
            int exist = this.GetAll().Where(x=>x.Token==token).ToList().Count;
            return exist>0?true:false;
        }

        public Guid Login(string userName, string password)
        {
            User user = userRepository.GetAll().Where(x=>x.UserName==userName && x.Password==password).First();
            if(user != null)
            {
                Guid token = Guid.NewGuid();
                UserSession us = new UserSession(){ Token = token, IsAdmin = user.IsAdmin, User = user };
                repository.Add(us);
                repository.Save();
                return token;
            }
            else
            {
                throw new Exception("El usuario y/o contraseña son incorrectos");
            }

        }

        public void LogOut(Guid token)
        {
            repository.Remove(new UserSession() { Token = token });
        }
    }
}
