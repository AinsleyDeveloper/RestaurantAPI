using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Models
{
    public class Waiter
    {
        public Waiter()
        {
        }

        public Waiter( int waiterId, string firstName, string lastName, string login, string password)
        {
            WaiterId = waiterId;
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
        }

        public int WaiterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}