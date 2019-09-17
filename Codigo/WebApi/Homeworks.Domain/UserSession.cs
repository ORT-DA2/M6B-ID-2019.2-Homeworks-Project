using System;

namespace Homeworks.Domain
{
    public class UserSession
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public User User { get; set; }
        public bool IsAdmin { get; set; }
        public UserSession() { }
    }
}
