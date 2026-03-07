using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalProductApi.Dtos;
using MinimalProductApi.Entities;

namespace MinimalProductApi.DbContexts
{
    public class CartRepository : ICartRepository
    {
        private readonly ProductDbContext _productDbContext;
        private readonly IMapper _mapper;

        public CartRepository(ProductDbContext productDbContext, IMapper mapper)
        {
            _productDbContext = productDbContext;
            _mapper = mapper;
        }

        public async Task DeleteCartProductAsync(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Product Id is not valid");

            var product = _productDbContext.Products.Single(p => p.Id == id);

            _productDbContext.Products.Remove(product);
            await _productDbContext.SaveChangesAsync();
        }        

        public async Task<IEnumerable<ProductDto>> GetCartProductsAsync()
        {
            var products = await _productDbContext.Products.ToListAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }

        public async Task SaveCartProductAsync(ProductDto productDto)
        {
            if (productDto == null)
                throw new ArgumentNullException(nameof(productDto));

            var product = _mapper.Map<Product>(productDto);

            await _productDbContext.Products.AddAsync(product);
            await _productDbContext.SaveChangesAsync();
        }        
    }
}
