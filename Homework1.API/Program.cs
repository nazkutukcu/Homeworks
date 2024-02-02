using Homework1.API.Models;
using Homework1.API.Models.Categories;
using Homework1.API.Models.Products;
using Homework1.API.Models.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

//Bu kod par�as�, uygulaman�n ba�lang�c�nda, AppDbContext s�n�f�n� kullanarak SQL Server veritaban�na ba�lanmak
//i�in gerekli olan ba�lant�y� ve di�er yap�land�rmalar� ekler. Bu sayede, AppDbContext s�n�f� �zerinden veritaban�
//ile etkile�imde bulunabilirsiniz.

// DbContext konfig�rasyonu
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});



// add behavior to the DI container
builder.Services.AddProductDIContainer();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IRedisExamples, RedisExamples>(_ => new RedisExamples("localhost:6379"));

//Redis sunucu ba�lant� dizesi (�rne�in, localhost:6379)
        string redisConnectionString = "localhost:6379";

// ConnectionMultiplexer'� ekledim
//�al��mas� i�in redis-server.exe �al��t�rmam�z gerekiyor yoksa hata verir.
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));



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
