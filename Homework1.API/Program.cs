using Homework1.API.Models;
using Homework1.API.Models.Categories;
using Homework1.API.Models.Products;
using Homework1.API.Models.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

//Bu kod parçasý, uygulamanýn baþlangýcýnda, AppDbContext sýnýfýný kullanarak SQL Server veritabanýna baðlanmak
//için gerekli olan baðlantýyý ve diðer yapýlandýrmalarý ekler. Bu sayede, AppDbContext sýnýfý üzerinden veritabaný
//ile etkileþimde bulunabilirsiniz.

// DbContext konfigürasyonu
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

//Redis sunucu baðlantý dizesi (örneðin, localhost:6379)
        string redisConnectionString = "localhost:6379";

// ConnectionMultiplexer'ý ekledim
//çalýþmasý için redis-server.exe çalýþtýrmamýz gerekiyor yoksa hata verir.
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
