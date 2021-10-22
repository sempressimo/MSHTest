using System;

namespace MSHTest.TaxJar.Client.Model
{
	public class TaxJarRate
    {
        public string City { get; set; }
		public decimal CityRate { get; set; }
		public decimal CombinedDistrictRate { get; set; }
		public decimal CombinedRate { get; set; }
		public string Country { get; set; }
		public decimal Country_Rate { get; set; }
		public string County { get; set; }
		public decimal CountyRate { get; set; }
		public bool FreightTaxable { get; set; }
		public string State { get; set; }
		public decimal StateRate { get; set; }
		public string Zip { get; set; }
	}

	public class TaxJarRatesForLocationResponse
	{
		public TaxJarRate Rate { get; set; }
	}
}
