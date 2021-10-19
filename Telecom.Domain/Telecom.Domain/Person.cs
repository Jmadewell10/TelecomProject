using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telecom.Domain
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Address { get; set; }

        public string dob { get; set; }

        public string UserName { get; set; }

        public Account account { get; set; }

        public int AccountNumber { get; set; }


    }
}
