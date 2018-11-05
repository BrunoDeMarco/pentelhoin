using System;
using System.Collections.Generic;
using System.Text;

namespace pentelhoin
{
    public class Transaction
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public int Amount { get; set; }
    }
}
