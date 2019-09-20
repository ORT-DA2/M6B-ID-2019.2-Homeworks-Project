using System;
using Homeworks.Domain;

namespace Homeworks.WebApi.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginModel(){ }

    }
} 