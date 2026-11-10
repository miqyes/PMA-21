using Microsoft.EntityFrameworkCore;
using Mapping.Data;

var builder = WebApplication.CreateBuilder(args);

// Контекст БД
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Сервіси
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyRestAPI V1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();