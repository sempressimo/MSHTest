using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSHTest.Common.DTO
{
    public class TaxForOrderRequestDTO
    {
        [JsonProperty(PropertyName = "from_country")]
        public string FromCountry { get; set; }

        [JsonProperty(PropertyName = "from_zip")]
        public string FromZip { get; set; }

        [JsonProperty(PropertyName = "from_state")]
        public string FromState { get; set; }

        [JsonProperty(PropertyName = "to_country")]
        public string ToCountry { get; set; }

        [JsonProperty(PropertyName = "to_zip")]
        public string ToZip { get; set; }

        [JsonProperty(PropertyName = "to_state")]
        public string ToState { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "shipping")]
        public decimal Shipping { get; set; }
    }
}
