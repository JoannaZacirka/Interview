using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var uri = args.Length > 0 ? args[0] : "https://docs.microsoft.com/dotnet";
                GetUrlContentLengthAsync(uri);
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

        static async void GetUrlContentLengthAsync(string uri)
        {
            var client = new HttpClient();

            Task<string> getStringTask = client.GetStringAsync(uri);

            DoIndependentWork();

            string contents = await getStringTask;
            Console.WriteLine($"Length={contents.Length}");
        }

        static void DoIndependentWork()
        {
            Console.WriteLine("Working ...");
        }
    }
}
