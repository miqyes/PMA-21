using Microsoft.EntityFrameworkCore;

var Builder = WebApplication.CreateBuilder(args);

Builder.Services.AddControllers();
Builder.Services.AddEndpointsApiExplorer();
Builder.Services.AddSwaggerGen();

Builder.Services.AddDbContext<AplicationDb>(options => options.UseSqlServer(Builder.Configuration.GetConnectionString("DefaultConnection")));

var App = Builder.Build();

App.UseSwagger();
App.UseSwaggerUI();

App.MapControllers();
App.Run();