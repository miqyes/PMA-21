using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/movies", async () =>
{
    var movies = new List<Movie>();
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();

    await using var command = new NpgsqlCommand("SELECT id, name, director, genre FROM movie", connection);
    await using var reader = await command.ExecuteReaderAsync();
    
    while (await reader.ReadAsync())
    {
        movies.Add(new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
    }

    return Results.Ok(movies);
});

app.MapGet("/movies/{id:int}", async (int id) =>
{
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();

    var command = new NpgsqlCommand("SELECT id, name, director, genre FROM movie WHERE id = @id", connection);
    command.Parameters.AddWithValue("id", id);

    await using var reader = await command.ExecuteReaderAsync();
    if (await reader.ReadAsync())
    {
        var movie = new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),reader.GetString(3));
        return Results.Ok(movie);
    }

    return Results.NotFound(new { Message = "Фільм не знайдено." });
});

app.MapPost("/movies", async (CreateMovieDto dto) =>
{
    if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Director)|| string.IsNullOrWhiteSpace(dto.Genre))
    {
        return Results.BadRequest(new { Message = "Поля name, director, genre обов'язкові." });

    }
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();

    var query = "INSERT INTO movie (name, director, genre) VALUES (@name, @director, @genre) RETURNING id, name, director, genre;";
    await using var command = new NpgsqlCommand(query, connection);
    command.Parameters.AddWithValue("name", dto.Name);
    command.Parameters.AddWithValue("director", dto.Director);
    command.Parameters.AddWithValue("genre", dto.Genre);


    await using var reader = await command.ExecuteReaderAsync();
    if (await reader.ReadAsync())
    {
        var createdMovie = new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
        return Results.Created($"/movies/{createdMovie.Id}", createdMovie);
    }

    return Results.BadRequest("Не вдалося створити фільм.");
});

app.MapPut("/movies/{id:int}", async (int id, CreateMovieDto dto) =>
{
    if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Director) || string.IsNullOrWhiteSpace(dto.Genre))
    {
        return Results.BadRequest(new { Message = "Поля name, director, genre обов'язкові." });
    }

    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();

    var query = "UPDATE movie SET name = @name, director = @director, genre = @genre WHERE id = @id RETURNING id, name, director, genre;";
    await using var command = new NpgsqlCommand(query, connection);
    command.Parameters.AddWithValue("id", id);
    command.Parameters.AddWithValue("name", dto.Name);
    command.Parameters.AddWithValue("director", dto.Director);
    command.Parameters.AddWithValue("genre", dto.Genre);

    await using var reader = await command.ExecuteReaderAsync();
    if (await reader.ReadAsync())
    {
        var updatedMovie = new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
        return Results.Ok(updatedMovie);
    }

    return Results.NotFound(new { Message = "Фільм для оновлення не знайдено." });
});

app.MapPatch("/movies/{id:int}", async (int id, PatchMovieDto dto) =>
{
    if (dto.Name == null && dto.Director == null && dto.Genre == null)
    {
        return Results.BadRequest(new { Message = "Передай хоча б одне поле для оновлення." });
    }
    if ((dto.Name != null && string.IsNullOrWhiteSpace(dto.Name)) || (dto.Director != null && string.IsNullOrWhiteSpace(dto.Director)) ||
        (dto.Genre != null && string.IsNullOrWhiteSpace(dto.Genre)))
    {
        return Results.BadRequest(new { Message = "Передані поля не можуть бути порожніми." });
    }
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();

    var query = "UPDATE movie SET name = COALESCE(@name, name), director = COALESCE(@director, director), genre = COALESCE(@genre, genre) WHERE id = @id RETURNING id, name, director, genre;";
    await using var command = new NpgsqlCommand(query, connection);
    command.Parameters.AddWithValue("id", id);
    command.Parameters.AddWithValue("name", (object?)dto.Name ?? DBNull.Value);
    command.Parameters.AddWithValue("director", (object?)dto.Director ?? DBNull.Value);
    command.Parameters.AddWithValue("genre", (object?)dto.Genre ?? DBNull.Value);


    await using var reader = await command.ExecuteReaderAsync();
    if (await reader.ReadAsync())
    {
        var updatedMovie = new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),reader.GetString(3));
        return Results.Ok(updatedMovie);
    }

    return Results.NotFound(new { Message = "Фільм для оновлення не знайдено." });
});

app.MapDelete("/movies/{id:int}", async (int id) =>
{
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();

    var command = new NpgsqlCommand("DELETE FROM movie WHERE id = @id", connection);
    command.Parameters.AddWithValue("id", id);

    var rowsAffected = await command.ExecuteNonQueryAsync();
    if (rowsAffected > 0)
    {
        return Results.NoContent();
    }

    return Results.NotFound(new { Message = "Фільм для видалення не знайдено." });
});

app.Run();

record Movie(int Id, string Name, string Director, string Genre);
record CreateMovieDto(string Name, string Director, string Genre);
record PatchMovieDto(string? Name, string? Director, string? Genre);