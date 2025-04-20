using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanaceManagementSystem.model
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Users() { }

        public Users(int userId, string username, string password, string email)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Email = email;
        }
        public override string ToString()
        {
            return $"UserId: {UserId}, Username: {Username}, Email: {Email}";
        }
 
    }
}
