using Newtonsoft.Json;
using System.Net.Http;

namespace Job.Customer.ExecuteCustomer.ExternalServices.Contents
{
    public static class HttpResponseExtensios
    {
        public static T ContentAsType<T>(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return string.IsNullOrEmpty(data) ?
                            default(T) :
                            JsonConvert.DeserializeObject<T>(data);
        }
    }
}
