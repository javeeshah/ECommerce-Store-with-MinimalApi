using MinimalProductApi.Dtos;
using MinimalProductApi.Entities;

namespace MinimalProductApi.DbContexts
{
    public interface ICartRepository
    {
        Task SaveCartProductAsync(ProductDto productDto);

        Task<IEnumerable<ProductDto>> GetCartProductsAsync();

        Task DeleteCartProductAsync(int id);
    }
}
