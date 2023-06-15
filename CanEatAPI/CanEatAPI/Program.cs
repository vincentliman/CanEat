using CanEatAPI;
using CanEatAPI.Helper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CanEatDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"))
);

builder.Services.AddScoped<CompanyHelper>();
builder.Services.AddScoped<FoodHelper>();
builder.Services.AddScoped<ShopHelper>();
builder.Services.AddScoped<CustomerHelper>();
builder.Services.AddScoped<TrHeaderHelper>();
builder.Services.AddScoped<TrDetailHelper>();
builder.Services.AddScoped<CartHelper>();


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


