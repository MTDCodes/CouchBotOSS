using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Helpers
{
    public static class ApiHelper
    {
        public static async Task<T> GetAsync<T>(string url, 
            CancellationToken cancellationToken,
            List<(string name, string value)> headers = null)
        {
            try
            {
                using var client = new HttpClient();

                if (headers?.Count > 0)
                {
                    foreach (var (name, value) in headers)
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation(name, value);
                    }
                }

                var response = await client.GetAsync(url, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Matt needs to do better. Tell him this.");
                    return default;
                }

                var responseText = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<T>(responseText);
            }
            catch (Exception)
            {
                Console.WriteLine("Matt needs to do better. Tell him this.");
                return default;
            }
        }

        public static async Task<T> PostAsync<T>(string url,
            CancellationToken cancellationToken,
            List<(string name, string value)> headers = null, 
            string payloadString = null)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers?.Count > 0)
                {
                    foreach (var (name, value) in headers)
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation(name, value);
                    }
                }

                StringContent content = null;
                if (!string.IsNullOrWhiteSpace(payloadString))
                {
                    content = new StringContent(payloadString, Encoding.UTF8, "application/json");
                }

                var response = await client.PostAsync(url, content, cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Matt needs to do better. Tell him this.");
                    return default;
                }

                var responseText = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<T>(responseText);
            }
            catch (Exception)
            {
                Console.WriteLine("Matt needs to do better. Tell him this.");
                return default;
            }
        }
    }
}
