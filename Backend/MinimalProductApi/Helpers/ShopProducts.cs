using MinimalProductApi.Entities;
using System.Text.Json;

namespace MinimalProductApi.Helpers
{
    public static class ShopProducts
    {
        public static IEnumerable<Product> GetAllShopProducts()
        {
            var jsonString = File.ReadAllText("shop-products.json");

            var productsJson = JsonSerializer.Deserialize<List<ProductJson>>(jsonString,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });


            return productsJson!.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageName = p.ImageName,
                Category = p.Category,
                Price = p.Price,
                Discount = p.Discount,
                CreatedAt = DateTime.UtcNow
            }).ToList();
        }
    }
}
