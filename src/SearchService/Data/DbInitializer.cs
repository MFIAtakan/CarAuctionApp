using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Services;
using System.Text.Json;

namespace SearchService.Data
{
    public class DbInitializer
    {

        public static async Task InitDb(WebApplication application)
        {
            await DB.InitAsync("SearchDB", MongoClientSettings
                                    .FromConnectionString(application.Configuration.GetConnectionString("MongoDBConnectionString")));

            await DB.Index<Item>()
                .Key(x => x.Make, KeyType.Text)
                .Key(x => x.Model, KeyType.Text)
                .Key(x => x.Color, KeyType.Text)
                .CreateAsync();

            var count = await DB.CountAsync<Item>();

           if (count == 0)
            {
                Console.WriteLine("There is no data. Will be seeded!");
                var itemData = await File.ReadAllTextAsync("Data/auctions.json");

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var _items = JsonSerializer.Deserialize<List<Item>>(itemData, options);

                await DB.SaveAsync(_items);
            }

            using var scope = application.Services.CreateScope();

            var httpClient = scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClient>();
            var items = await httpClient.GetItemsForSearchDb();

            if(items.Count>0)
            {
                await DB.SaveAsync(items);
            }
        }
    }
}
