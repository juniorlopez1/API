using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Servicios
{
    public class webBaseService
    {
        private readonly string baseUrl;

        public webBaseService(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        protected async Task<T> GetAsync<T>(string uri)
        {
            var client = HttpClientFactory.Create();

            using var httpResponse = await client.GetAsync($"{baseUrl}/{uri}");
            var content = await httpResponse.Content.ReadAsStreamAsync();
            return DeserializeContent<T>(content);
        }

        protected async Task PostAsync<T>(string uri, T entidad)
        {
            var client = HttpClientFactory.Create();

            using var httpResponse = await client.PostAsJsonAsync($"{baseUrl}/{uri}", entidad);
        }

        protected async Task PutAsync<T>(string uri, T entidad)
        {
            var client = HttpClientFactory.Create();

            using var httpResponse = await client.PutAsJsonAsync($"{baseUrl}/{uri}", entidad);
        }

        protected async Task DeleteAsync(string uri)
        {
            var client = HttpClientFactory.Create();

            using var httpResponse = await client.DeleteAsync($"{baseUrl}/{uri}");
            var content = await httpResponse.Content.ReadAsStreamAsync();
        }

        private T DeserializeContent<T>(Stream content)
        {
            using var streamReader = new StreamReader(content);
            using var jsonReader = new JsonTextReader(streamReader);
            var serializer = new JsonSerializer();
            return serializer.Deserialize<T>(jsonReader);
        }
    }
}
