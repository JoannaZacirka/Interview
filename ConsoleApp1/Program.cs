using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var uri = args.Length > 0 ? args[0] : "https://docs.microsoft.com/dotnet";
                var length = GetUrlContentLengthAsync(uri).Result;
                Console.WriteLine($"Length={length}");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception caught!");
            }
            finally
            {
                Console.WriteLine("This is the end.");
            }
        }

        static async Task<int> GetUrlContentLengthAsync(string uri)
        {
            var client = new HttpClient();

            Task<string> getStringTask = client.GetStringAsync(uri);

            DoIndependentWork();

            string contents = await getStringTask;
            return contents.Length;
        }

        static void DoIndependentWork()
        {
            Console.WriteLine("Working ...");
        }
    }
}
