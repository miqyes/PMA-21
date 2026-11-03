using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var app = builder.Build();
await using (var connection = new NpgsqlConnection(connectionString))
{
    await connection.OpenAsync();

    var createTableQuery = @" CREATE TABLE IF NOT EXISTS products (id INTEGER PRIMARY KEY, name VARCHAR(100) NOT NULL, price NUMERIC(10,2) NOT NULL);";

    await using var command = new NpgsqlCommand(createTableQuery, connection);
    await command.ExecuteNonQueryAsync();
}
app.UseHttpsRedirection();

app.MapGet("/products", async () =>
{
    var products = new List<Product>();
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();

    await using var command = new NpgsqlCommand("SELECT id, name, price FROM products", connection);
    await using var reader = await command.ExecuteReaderAsync();
    
    while (await reader.ReadAsync())
    {
        products.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2)));
    }

    return Results.Ok(products);
});

app.MapGet("/products/{id:int}", async (int id) =>
{
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();

    var command = new NpgsqlCommand("SELECT id, name, price FROM products WHERE id = @id", connection);
    command.Parameters.AddWithValue("id", id);

    await using var reader = await command.ExecuteReaderAsync();
    if (await reader.ReadAsync())
    {
        var product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
        return Results.Ok(product);
    }

    return Results.NotFound(new { Message = "Товар не знайдено." });
});

app.MapPost("/products", async (CreateProductDto dto) =>
{
    try
    {
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        var query =
            "INSERT INTO products (id, name, price) VALUES (@id, @name, @price) RETURNING id, name, price;";

        await using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("id", dto.Id);
        command.Parameters.AddWithValue("name", dto.Name);
        command.Parameters.AddWithValue("price", dto.Price);

        await using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            var product = new Product(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetDecimal(2));

            return Results.Created($"/products/{product.Id}", product);
        }

        return Results.BadRequest();
    }
    catch (PostgresException ex) when (ex.SqlState == "23505")
    {
        return Results.BadRequest(
            new { Message = "Продукт з таким ID вже існує." });
    }
});


app.MapPatch("/products/{id:int}", async (int id, UpdateProductDto dto) =>
{
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();

    // Оновлюємо лише те, що передали, або залишаємо старе
    var query = @"UPDATE products 
                  SET name = COALESCE(@name, name), 
                      price = COALESCE(@price, price) 
                  WHERE id = @id 
                  RETURNING id, name, price;";
                  
    await using var command = new NpgsqlCommand(query, connection);
    command.Parameters.AddWithValue("id", id);
    command.Parameters.AddWithValue("name", (object?)dto.Name ?? DBNull.Value);
    command.Parameters.AddWithValue("price", (object?)dto.Price ?? DBNull.Value);

    await using var reader = await command.ExecuteReaderAsync();
    if (await reader.ReadAsync())
    {
        var updatedProduct = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
        return Results.Ok(updatedProduct);
    }

    return Results.NotFound(new { Message = "Товар для оновлення не знайдено." });
});

app.MapDelete("/products/{id:int}", async (int id) =>
{
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();

    var command = new NpgsqlCommand("DELETE FROM products WHERE id = @id", connection);
    command.Parameters.AddWithValue("id", id);

    var rowsAffected = await command.ExecuteNonQueryAsync();
    if (rowsAffected > 0)
    {
        return Results.NoContent();
    }

    return Results.NotFound(new { Message = "Товар для видалення не знайдено." });
});

app.Run();

record Product(int Id, string Name, decimal Price);
record CreateProductDto(int Id, string Name, decimal Price);
record UpdateProductDto(string? Name, decimal? Price);