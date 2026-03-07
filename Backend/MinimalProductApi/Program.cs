using MinimalProductApi.DbContexts;
using Microsoft.EntityFrameworkCore;
using MinimalProductApi.Dtos;
using MinimalProductApi.MapperConfigs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocal", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//Entity Framework configuration
builder.Services.AddDbContext<ProductDbContext>(options
    => options.UseInMemoryDatabase("ProductsDatabase"));

builder.Services.AddAutoMapper(config => config.AddProfile(typeof(MappingProfile)));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();

var app = builder.Build();

app.UseCors("AllowLocal");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/products",
    async (ProductDto productDto, IProductRepository productRepo) =>
    {
        await productRepo.SaveProductAsync(productDto);
        return Results.Created($"/products/{productDto.Id}", productDto);
    })
    .WithDescription("Create a new Store product")
    .Produces(201)
    .Produces(500);

app.MapPost("/cart/products",
    async (ProductDto productDto, ICartRepository productRepo) =>
    {
        await productRepo.SaveCartProductAsync(productDto);
        return Results.Created($"/cart/products/{productDto.Id}", productDto);
    })
    .WithDescription("Add a product to Cart")
    .Produces(201)
    .Produces(500);

app.MapGet("/products", 
    async (IProductRepository productRepo) =>
    {
        return await productRepo.GetAllProductsAsync();
    })
    .WithDescription("Get all Store products")
    .Produces(200)
    .Produces(500);

app.MapGet("/cart/products",
    async (ICartRepository productRepo) =>
    {
        return await productRepo.GetCartProductsAsync();
    })
    .WithDescription("Get all Cart products")
    .Produces(200)
    .Produces(500);

app.MapGet("/products/{productId:int}", 
    async (int productId, IProductRepository productRepo) =>
    {
        return await productRepo.GetProductByIdAsync(productId);
    })
    .WithDescription("Get a Store product by Id")
    .Produces(200)
    .Produces(404);

app.MapPut("/products/{productId:int}",     
    async (int productId, ProductDto productDto, IProductRepository productRepo) =>
    {
        await productRepo.UpdateProductAsync(productId, productDto);
        return Results.Ok();
    })
    .WithDescription("Update a Store product")
    .Produces(200)
    .Produces(404);

app.MapDelete("/products/{productId:int}",
    async (int productId, IProductRepository productRepo) =>
    {
        await productRepo.DeleteProductAsync(productId);
        return Results.Ok();
    })
    .WithDescription("Delete a Store product")
    .Produces(200)
    .Produces(404);

app.MapDelete("/cart/products/{productId:int}",     
    async (int productId, ICartRepository productRepo) =>
    {
        await productRepo.DeleteCartProductAsync(productId);
        return Results.Ok();
    })
    .WithDescription("Delete a Cart product")
    .Produces(200)
    .Produces(404);

app.Run();

