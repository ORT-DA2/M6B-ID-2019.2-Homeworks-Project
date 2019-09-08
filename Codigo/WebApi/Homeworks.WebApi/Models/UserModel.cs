using System;
using Homeworks.Domain;

namespace Homeworks.WebApi.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public UserModel() { }
        public UserModel(User entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.UserName = entity.UserName;
            this.Password = entity.Password;
            this.IsAdmin = entity.IsAdmin;
        }
        public User ToEntity()
        {
            User user = new User()
            {
                Id = this.Id,
                UserName = this.UserName,
                Password = this.Password,
                Name = this.Name,
                IsAdmin = this.IsAdmin
            };
            return user;
        }

    }
} 