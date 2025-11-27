using System.Threading.Tasks;
var http = new HttpClient();
var tasks = new List<Task>();

for (int i = 0; i < 150; i++)
{
    tasks.Add(Task.Run(async() =>
    {
        var response0 = await http.GetAsync("https://localhost:7177/api/products-mn");
        var response1 = await http.GetAsync("https://localhost:7177/api/products");
        Console.WriteLine($"Request {i}: {response0.StatusCode}, {response1.StatusCode}");

    }));
}

await Task.WhenAll(tasks);