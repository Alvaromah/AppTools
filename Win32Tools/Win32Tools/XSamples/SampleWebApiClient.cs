using System;
using System.IO;
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

                try
                {
                    var result1 = await cli.GetAsync("api/values/1234", QueryParam.Create("param1", "p1"), QueryParam.Create("param2", "p2"));
                    Console.WriteLine(result1);

                    var result2 = await cli.PostAsync<MyClass>("api/values/1234", new MyClass { Name = "Sample" });
                    Console.WriteLine(result2);

                    var result3 = await cli.PutAsync<MyClass>("api/values/1234", new MyClass { Name = "Sample" });
                    Console.WriteLine(result3);

                    var result4 = await cli.DeleteAsync("api/values/1234");
                    Console.WriteLine(result4);

                    using (var stream = new FileStream("..\\..\\Assets\\Image.jpg", FileMode.Open))
                    {
                        var result5 = await cli.PutStreamAsync("api/upload/1234", stream);
                        Console.WriteLine(result5);
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Exception
                try
                {
                    var resultError = await cli.GetAsync<MyClass>("api/values/0", QueryParam.Create("param1", "p1"), QueryParam.Create("param2", "p2"));
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
