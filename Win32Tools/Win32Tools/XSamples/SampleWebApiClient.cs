using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Win32Tools
{
    static public class SampleWebApiClient
    {
        static public void Run()
        {
            RunAsync().Wait();
        }

        static private async Task RunAsync()
        {
            using (var cli = new WebApiClient("http://localhost:49968"))
            {
                cli.AuthorizationToken = "AuthorizationToken";

                var result1 = cli.GetAsync<object>("api/values/1234", QueryParam.Create("param1", "p1"), QueryParam.Create("param2", "p2"));
                Console.WriteLine(await result1);

                var result2 = cli.PostAsync<MyClass>("api/values/1234", new MyClass { Name = "Sample" });
                Console.WriteLine(await result2);

                try
                {
                    var resultError = cli.GetAsync<MyClass>("api/values/0", QueryParam.Create("param1", "p1"), QueryParam.Create("param2", "p2"));
                    Console.WriteLine(await resultError);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public class MyClass
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return $"[Id = {Id}, Name = {Name}]";
            }
        }
    }
}
