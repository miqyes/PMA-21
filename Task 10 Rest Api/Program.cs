using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    for (var attempt = 1; ; attempt++)
    {
        try
        {
            db.Database.EnsureCreated();
            break;
        }
        catch when (attempt < 10)
        {
            Thread.Sleep(3000);
        }
    }
}

app.UseExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
