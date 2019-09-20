using System;
using System.Collections.Generic;

namespace Homeworks.BusinessLogic.Interface
{
    public interface ISession<T>
    {
        Guid Login(string userName, string password);
        void LogOut(Guid token);
        IEnumerable<T> GetAll();
        bool IsAdmin(Guid token);
        bool isLogued(Guid token);
    }
}
