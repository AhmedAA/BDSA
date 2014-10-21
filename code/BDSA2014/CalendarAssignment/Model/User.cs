using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Model
{
    class User
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public bool IsLoggedIn { get; private set; }

        public void LogIn()
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
