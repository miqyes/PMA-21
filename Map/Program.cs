using StudentAPI.Services;
using StudentAPI.Settings;
using StudentAPI.Mapping;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddXmlSerializerFormatters();

builder.Services.Configure<MongoDb>(
    builder.Configuration.GetSection("MongoDb")
);
builder.Services.AddSingleton<StudentServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
StudentMappingConfig.Register();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();