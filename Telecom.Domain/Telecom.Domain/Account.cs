using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telecom.Domain
{
    public class Account
    {
        public int AccountNumber { get; set; }

        public string UserName { get; set; }

        public List<PlanOptions> Plan { get; set; }

        public List<Person> People { get; set; }

    }
}
