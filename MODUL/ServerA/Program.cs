using MongoDB.Driver;
using ServerA.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails(o =>
    o.CustomizeProblemDetails = ctx =>
    {
        if (ctx.ProblemDetails.Status == 400)
            ctx.ProblemDetails.Title = "Помилка валідації даних";
    });
builder.Services.AddSingleton<IMongoClient>(
    _ => new MongoClient(builder.Configuration["Mongo:Connection"]));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IMongoClient>()
        .GetDatabase(builder.Configuration["Mongo:Database"])
        .GetCollection<PatientDocument>("patients"));

builder.Services.AddHttpClient("serviceB", c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceB:BaseUrl"]!));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI(); 
}
app.MapPost("/patients", async (
    PatientDocument patient,
    IMongoCollection<PatientDocument> collection,
    IHttpClientFactory httpFactory) =>
{

    await collection.ReplaceOneAsync(
        p => p.Id == patient.Id,
        patient,
        new ReplaceOptions { IsUpsert = true });

    var client = httpFactory.CreateClient("serviceB");
    var response = await client.PostAsJsonAsync("/patients", patient);

    if (!response.IsSuccessStatusCode)
        return Results.Problem(
            $"Service B returned {(int)response.StatusCode}",
            statusCode: StatusCodes.Status502BadGateway);

    return Results.Accepted($"/patients/{patient.Id}", new { patient.Id });
});
app.MapGet("/patients", async (IMongoCollection<PatientDocument> collection) =>
    Results.Ok(await collection.Find(_ => true).ToListAsync()));   

app.MapGet("/patients/{id}", async (string id, IMongoCollection<PatientDocument> collection) =>
{
    var patient = await collection.Find(p => p.Id == id).FirstOrDefaultAsync();
    return patient is null ? Results.NotFound() : Results.Ok(patient);
});

app.MapPut("/patients/{id}", async (
    string id,
    PatientDocument patient,                        
    IMongoCollection<PatientDocument> collection,
    IHttpClientFactory httpFactory) =>
{
    if (id != patient.Id)                           
        return Results.BadRequest(new { error = "Id в адресі та в тілі запиту відрізняються" });

    var result = await collection.ReplaceOneAsync(p => p.Id == id, patient);   
    if (result.MatchedCount == 0) return Results.NotFound();

    var response = await httpFactory.CreateClient("serviceB").PostAsJsonAsync("/patients", patient);
    return response.IsSuccessStatusCode
        ? Results.Ok(patient)
        : Results.Problem($"Service B returned {(int)response.StatusCode}", statusCode: StatusCodes.Status502BadGateway);
});

app.MapPatch("/patients/{id}", async (
    string id,
    PatientPatch patch,                              
    IMongoCollection<PatientDocument> collection,
    IHttpClientFactory httpFactory) =>
{
    var patient = await collection.Find(p => p.Id == id).FirstOrDefaultAsync();
    if (patient is null) return Results.NotFound();

    if (patch.Name is not null) patient.Name = patch.Name;              
    if (patch.Blood is not null) patient.Blood = patch.Blood;
    if (patch.BirthDate is not null) patient.BirthDate = patch.BirthDate.Value;
    if (patch.Allergies is not null) patient.Allergies = patch.Allergies;
    if (patch.Visits is not null) patient.Visits = patch.Visits;

    await collection.ReplaceOneAsync(p => p.Id == id, patient);         

    var response = await httpFactory.CreateClient("serviceB").PostAsJsonAsync("/patients", patient);
    return response.IsSuccessStatusCode
        ? Results.Ok(patient)
        : Results.Problem($"Service B returned {(int)response.StatusCode}", statusCode: StatusCodes.Status502BadGateway);
});

app.MapDelete("/patients/{id}", async (
    string id,
    IMongoCollection<PatientDocument> collection,
    IHttpClientFactory httpFactory) =>
{
    var result = await collection.DeleteOneAsync(p => p.Id == id);
    if (result.DeletedCount == 0) return Results.NotFound();

    var response = await httpFactory.CreateClient("serviceB")
        .DeleteAsync($"/patients/{Uri.EscapeDataString(id)}");          
    if (!response.IsSuccessStatusCode && response.StatusCode != System.Net.HttpStatusCode.NotFound)
        return Results.Problem($"Service B returned {(int)response.StatusCode}", statusCode: StatusCodes.Status502BadGateway);

    return Results.NoContent();                      
});

app.Run();