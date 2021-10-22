using MSHTest.TaxJar.Client.Model;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHTest.Infrastructure.ApiClients
{
    public class TaxJarClient
    {
        private readonly string _apiBaseUrl;

        IRestClient _client;

        public TaxJarClient(string ApiKey)
        {
            _apiBaseUrl = "https://api.taxjar.com/v2/";
            _client = new RestClient(_apiBaseUrl);
            _client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", ApiKey));
        }

        public TaxJarTaxForOrderResponse TaxForOrder(TaxJarTaxForOrderRequest taxJarTaxForOrderRequest)
        {
            IRestRequest request = new RestRequest("taxes", Method.POST);

            request.AddJsonBody(taxJarTaxForOrderRequest);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                JsonDeserializer deserial = new JsonDeserializer();

                TaxJarTaxForOrderResponse taxJarTaxForOrderResponse =
                    deserial.Deserialize<TaxJarTaxForOrderResponse>(response);

                return taxJarTaxForOrderResponse;
            }
            else
            {
                // Future work: Log the error
                throw new ApplicationException($"{response.StatusDescription} {response.ErrorMessage}");
            }
        }

        public async Task<TaxJarTaxForOrderResponse> TaxForOrderAsyc(TaxJarTaxForOrderRequest taxJarTaxForOrderRequest)
        {
            IRestRequest request = new RestRequest("taxes", Method.POST);

            request.AddJsonBody(taxJarTaxForOrderRequest);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                JsonDeserializer deserial = new JsonDeserializer();

                TaxJarTaxForOrderResponse taxJarTaxForOrderResponse =
                    deserial.Deserialize<TaxJarTaxForOrderResponse>(response);

                return await Task.FromResult(taxJarTaxForOrderResponse);
            }
            else
            {
                // Future work: Log the error
                throw new ApplicationException($"{response.StatusDescription} {response.ErrorMessage}");
            }
        }

        public TaxJarRatesForLocationResponse GetTaxRatesForLocation(string zipCode)
        {
            IRestRequest request = new RestRequest($"rates/{zipCode}", Method.GET);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                JsonDeserializer deserial = new JsonDeserializer();

                TaxJarRatesForLocationResponse taxJarRatesForLocationResponse = deserial.Deserialize<TaxJarRatesForLocationResponse>(response);

                return taxJarRatesForLocationResponse;
            }
            else
            {
                // Future work: Log the error
                throw new ApplicationException($"{response.StatusDescription} {response.ErrorMessage}");
            }
        }

        public async Task<TaxJarRatesForLocationResponse> GetTaxRatesForLocationAsync(string zipCode)
        {
            IRestRequest request = new RestRequest($"rates/{zipCode}", Method.GET);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                JsonDeserializer deserial = new JsonDeserializer();

                TaxJarRatesForLocationResponse taxJarRatesForLocationResponse = deserial.Deserialize<TaxJarRatesForLocationResponse>(response);

                return await Task.FromResult(taxJarRatesForLocationResponse);
            }
            else
            {
                // Future work: Log the error
                throw new ApplicationException($"{response.StatusDescription} {response.ErrorMessage}");
            }
        }
    }
}
