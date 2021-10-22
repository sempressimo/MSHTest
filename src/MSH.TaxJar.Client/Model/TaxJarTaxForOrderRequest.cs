using System;
using System.Collections.Generic;
using System.Text;

namespace MSHTest.TaxJar.Client.Model
{
    public class TaxJarTaxForOrderRequest
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public decimal amount { get; set; }
        public decimal shipping { get; set; }
    }
}
