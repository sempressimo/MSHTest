using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSHTest.Common.DTO
{
    public class JurisdictionsDTO
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string State { get; set; }
    }

    public class TaxForOrderResultsDTO
    {
        public decimal AmountToCollect { get; set; }
        public bool FreightTaxable { get; set; }
        public bool HasNexus { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public decimal Rate { get; set; }
        public decimal Shipping { get; set; }
        public string TaxSource { get; set; }
        public decimal TaxableAmount { get; set; }

        public JurisdictionsDTO Jurisdictions { get; set; }
    }
}
