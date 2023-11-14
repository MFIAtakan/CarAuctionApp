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
            var result = DB.InitAsync("SearchDb", MongoClientSettings
                                    .FromConnectionString(application.Configuration.GetConnectionString("MongoDBConnectionString")));

            Console.WriteLine("***Connection granted*** |||||| Result for database operation is :" + result.ToString());
            Console.WriteLine("***Connection granted*** |||||| Message for database operation is :" + result.Exception.Message);
            Console.WriteLine("***Connection granted*** |||||| InnerMessage for database operation is :" + result.Exception.InnerException);
            Console.WriteLine("***Connection granted*** |||||| StackTrace for database operation is :" + result.Exception.StackTrace);
            Console.WriteLine("***Connection granted*** |||||| IsCompleted for database operation is :" + result.IsCompletedSuccessfully);

            await DB.Index<Item>()
                .Key(x => x.Make, KeyType.Text)
                .Key(x => x.Model, KeyType.Text)
                .Key(x => x.Color, KeyType.Text)
                .CreateAsync();

            var count = await DB.CountAsync<Item>();
            Console.WriteLine("***Count calculated*** |||||| Count of the auctions in SearchDb is :" + count.ToString());

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
