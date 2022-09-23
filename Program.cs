using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using static IntrusionDetectionSystem.PrometheusParser; 


namespace IntrusionDetectionSystem
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient(); 
        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear(); 
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")); 
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter"); 

            var stringTask = client.GetStringAsync("http://127.0.0.1:4000/metrics");
           // var metrics = await JsonSerializer.DeserializeAsync<List<Metrics>>(await streamTask);
            var msg = await stringTask; 
           // Console.Write(msg); 
            Parse(await stringTask); 
          
        }
        static async Task Main(String[] args)
        {
            await ProcessRepositories();
        }

    }

}




