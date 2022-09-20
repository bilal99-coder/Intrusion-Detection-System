using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
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

            var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

            var msg = await stringTask; 

            Console.Write(msg); 
        }
        static async Task Main(String[] args)
        {
            await ProcessRepositories();
        }

    }

}




