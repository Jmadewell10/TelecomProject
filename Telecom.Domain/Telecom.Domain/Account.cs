﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telecom.Domain
{
    public class Account
    {
        public int AccountNumber { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

    }
}
