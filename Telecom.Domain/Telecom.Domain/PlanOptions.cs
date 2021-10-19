using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telecom.Domain
{
    public class PlanOptions
    {
        public string PlanId{ get; set; }

        public int NumberOfDevices { get; set; }

        public string PlanName { get; set; }

        public bool IsUnlimited{ get; set; }

        public double Price{ get; set; }

        public List<Account> Accounts { get; set; }
    }
}
