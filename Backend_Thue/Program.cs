using Backend_Thue.Data;
using Backend_Thue.Interface;
using Backend_Thue.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
    option.UseLazyLoadingProxies();
});
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<ICoffeeRepository, CoffeeService>();
builder.Services.AddScoped<ICartRepository, CartService>();
builder.Services.AddScoped<IFavouriteRepository, FavouriteService>();
builder.Services.AddScoped<ICartRepository, CartService>();
builder.Services.AddScoped<IOrderRepository, OrderService>();

builder.Services.AddMvcCore().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = (errorContext) =>
    {
        var errors = errorContext.ModelState.Values.SelectMany(e => e.Errors.Select(m => new
        {
            ErrorMessage = m.ErrorMessage
        })).ToList();
        return new BadRequestObjectResult(errors[0].ErrorMessage);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
