﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DataProvider
{
    public class LoginValidator
    {
        public string message { get; set; }
        public BigInteger status { get; set; }
        public string tokenNo { get; set; }
        public string CustomerSubscriptionGuid { get; set; }
        public string MachineKey { get; set; }
        public int Customer { get; set; }
        public int Product { get; set; }

    }
}
