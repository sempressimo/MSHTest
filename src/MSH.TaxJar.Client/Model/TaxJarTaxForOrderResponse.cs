using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

/*
 {
    "tax": {
        "amount_to_collect": 1.09,
        "breakdown": {
            "city_tax_collectable": 0.0,
            "city_tax_rate": 0.0,
            "city_taxable_amount": 0.0,
            "combined_tax_rate": 0.06625,
            "county_tax_collectable": 0.0,
            "county_tax_rate": 0.0,
            "county_taxable_amount": 0.0,
            "line_items": [
                {
                    "city_amount": 0.0,
                    "city_tax_rate": 0.0,
                    "city_taxable_amount": 0.0,
                    "combined_tax_rate": 0.06625,
                    "county_amount": 0.0,
                    "county_tax_rate": 0.0,
                    "county_taxable_amount": 0.0,
                    "id": "1",
                    "special_district_amount": 0.0,
                    "special_district_taxable_amount": 0.0,
                    "special_tax_rate": 0.0,
                    "state_amount": 0.99,
                    "state_sales_tax_rate": 0.06625,
                    "state_taxable_amount": 15.0,
                    "tax_collectable": 0.99,
                    "taxable_amount": 15.0
                }
            ],
            "shipping": {
                "city_amount": 0.0,
                "city_tax_rate": 0.0,
                "city_taxable_amount": 0.0,
                "combined_tax_rate": 0.06625,
                "county_amount": 0.0,
                "county_tax_rate": 0.0,
                "county_taxable_amount": 0.0,
                "special_district_amount": 0.0,
                "special_tax_rate": 0.0,
                "special_taxable_amount": 0.0,
                "state_amount": 0.1,
                "state_sales_tax_rate": 0.06625,
                "state_taxable_amount": 1.5,
                "tax_collectable": 0.1,
                "taxable_amount": 1.5
            },
            "special_district_tax_collectable": 0.0,
            "special_district_taxable_amount": 0.0,
            "special_tax_rate": 0.0,
            "state_tax_collectable": 1.09,
            "state_tax_rate": 0.06625,
            "state_taxable_amount": 16.5,
            "tax_collectable": 1.09,
            "taxable_amount": 16.5
        },
        "freight_taxable": true,
        "has_nexus": true,
        "jurisdictions": {
            "city": "RAMSEY",
            "country": "US",
            "county": "BERGEN",
            "state": "NJ"
        },
        "order_total_amount": 16.5,
        "rate": 0.06625,
        "shipping": 1.5,
        "tax_source": "destination",
        "taxable_amount": 16.5
    }
}
 */

namespace MSHTest.TaxJar.Client.Model
{
    public class TaxJarTax
    {
        public decimal AmountToCollect { get; set; }
        public bool FreightTaxable { get; set; }
        public bool HasNexus { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public decimal Rate { get; set; }
        public decimal Shipping { get; set; }
        public string TaxSource { get; set; }
        public decimal TaxableAmount { get; set; }

        public TaxJarJurisdictions Jurisdictions { get; set; }
    }

    public class TaxJarTaxForOrderResponse
    {
        public TaxJarTax Tax { get; set; }
    }
}
