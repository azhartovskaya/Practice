using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Task6.Solution;

class Program
{
    static async Task Main()
    {
        var urls = new[] { "https://google.com", "https://yahoo.com", "https://bing.com" };

        try
        {
            var tasks = new Task<string>[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {
                tasks[i] = LoadPageAsync(urls[i]);
            }

            var results = await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                Console.WriteLine($"Длина содержимого страницы: {result.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке страниц: {ex.Message}");
        }
    }

    static async Task<string> LoadPageAsync(string url)
    {
        using var client = new HttpClient();
        return await client.GetStringAsync(url);
    }
}
