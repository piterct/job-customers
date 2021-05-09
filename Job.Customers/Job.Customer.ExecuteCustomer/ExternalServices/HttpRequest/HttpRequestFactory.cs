using Job.Customer.ExecuteCustomer.ExternalServices.Contents;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Job.Customer.ExecuteCustomer.ExternalServices.HttpRequest
{
    public static class HttpRequestFactory
    {
        public static async Task<HttpResponseMessage> Get(string requestUri, string token = "")
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Get)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(token);


            return await builder.SendAsync();
        }
        public static async Task<HttpResponseMessage> Get(string requestUri, int timeout, string token = "")
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Get)
                                .AddRequestUri(requestUri)
                                .AddTimeout(TimeSpan.FromSeconds(timeout))
                                .AddBearerToken(token);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Post(
        string requestUri, object value, string token = "")
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var request = new HttpClient(clientHandler);
            var body = JsonConvert.SerializeObject(value);
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await request.PostAsync(requestUri, httpContent);

            return response;
        }

        public static async Task<HttpResponseMessage> PostUrl(
        string requestUri, string token = "")
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var request = new HttpClient(clientHandler);
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var httpContent = new StringContent("", Encoding.UTF8, "application/json");
            var response = await request.PostAsync(requestUri, httpContent);

            return response;
        }

        public static async Task<HttpResponseMessage> Put(
          string requestUri, object value, string token = "")
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Put)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(token);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Delete(string requestUri, string token = "")
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Delete)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(token);

            return await builder.SendAsync();
        }
    }
}
