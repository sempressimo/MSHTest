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
        public decimal amount_to_collect { get; set; }
        public bool freight_taxable { get; set; }
        public bool has_nexus { get; set; }
        public decimal order_total_amount { get; set; }
        public decimal rate { get; set; }
        public decimal shipping { get; set; }
        public string tax_source { get; set; }
        public decimal taxable_amount { get; set; }

        public JurisdictionsDTO Jurisdictions { get; set; }
    }
}
