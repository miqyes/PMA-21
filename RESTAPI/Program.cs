using Microsoft.EntityFrameworkCore;
using TRY.Data;
using TRY.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PhoneDb>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var phoneItems = app.MapGroup("/Phoneitems");

phoneItems.MapGet("/", GetAllPhones);
phoneItems.MapGet("/Iphone", GetIPhones);
phoneItems.MapGet("/price/{price}", GetByPrice);
phoneItems.MapGet("/{id}/appleid", GetAppleID);
phoneItems.MapGet("/{id}", GetPhone);
phoneItems.MapPost("/", CreatePhone);
phoneItems.MapPut("/{id}", UpdatePhone);
phoneItems.MapPatch("/{id}", PatchPhone);
phoneItems.MapDelete("/{id}", DeletePhone);

app.Run();

static async Task<IResult> GetAllPhones(PhoneDb db)
{
    return TypedResults.Ok(await db.Phones.Select(x => new PhoneDTO(x)).ToArrayAsync());
}

static async Task<IResult> GetIPhones(PhoneDb db)
{
    return TypedResults.Ok(await db.Phones.Where(t => t.Iphone).Select(x => new PhoneDTO(x)).ToListAsync());
}

static async Task<IResult> GetByPrice(int price, PhoneDb db)
{
    return TypedResults.Ok(await db.Phones.Where(t => t.Price <= price).Select(x => new PhoneDTO(x)).ToListAsync());
}

static async Task<IResult> GetPhone(int id, PhoneDb db)
{
    var phone = await db.Phones.FindAsync(id);

    if (phone is null)
        return TypedResults.NotFound($"Телефон з ID {id} не знайдено");

    return TypedResults.Ok(new PhoneDTO(phone));
}

static async Task<IResult> GetAppleID(int id, PhoneDb db)
{
    var phone = await db.Phones.FindAsync(id);

    if (phone is null)
        return TypedResults.NotFound($"Телефон з ID {id} не знайдено");
    if (string.IsNullOrWhiteSpace(phone.AppleID))
        return TypedResults.NotFound($"Телефон не містить Apple ID");
    return TypedResults.Ok(new { phone.Id,phone.Name,phone.AppleID });
}

static async Task<IResult> CreatePhone(PhoneDTO phoneDTO, PhoneDb db)
{
    if (!string.IsNullOrWhiteSpace(phoneDTO.AppleID))
    {
        bool appleIdExists = await db.Phones
            .AnyAsync(p => p.AppleID == phoneDTO.AppleID);

        if (appleIdExists)
            return TypedResults.Conflict(
                $"Телефон з AppleID '{phoneDTO.AppleID}' вже існує");
    }
    if (!phoneDTO.Iphone && !string.IsNullOrWhiteSpace(phoneDTO.AppleID))
        return TypedResults.BadRequest(
            "Не можна вказувати AppleID, якщо Iphone = false");
   
    if (string.IsNullOrWhiteSpace(phoneDTO.Name))
        return TypedResults.BadRequest("Назва обов'язкова");
    if (phoneDTO.Price < 0) return TypedResults.BadRequest("Ціна не може бути від'ємною");
    if (phoneDTO.Battery < 0 || phoneDTO.Battery > 100) return TypedResults.BadRequest("Батарея має бути 0-100");
    

    var PhoneItem = new Phone
    {
        Battery = phoneDTO.Battery,
        Name = phoneDTO.Name,
        Price = phoneDTO.Price,
        Iphone = phoneDTO.Iphone,
        AppleID = phoneDTO.AppleID
    };

    db.Phones.Add(PhoneItem);
    await db.SaveChangesAsync();

    phoneDTO = new PhoneDTO(PhoneItem);

    return TypedResults.Created($"/Phoneitems/{PhoneItem.Id}", phoneDTO);
}

static async Task<IResult> UpdatePhone(int id, PhoneDTO phoneDTO, PhoneDb db)
{
    if (!phoneDTO.Iphone && !string.IsNullOrWhiteSpace(phoneDTO.AppleID))
        return TypedResults.BadRequest(
            "Не можна вказувати AppleID, якщо Iphone = false");
    var phone = await db.Phones.FindAsync(id);

    if (phone is null)
        return TypedResults.NotFound($"Телефон з ID {id} не знайдено");

    if (string.IsNullOrWhiteSpace(phoneDTO.Name))
        return TypedResults.BadRequest("Назва обов'язкова");
    if (phoneDTO.Price < 0) return TypedResults.BadRequest("Ціна не може бути від'ємною");
    if (phoneDTO.Battery < 0 || phoneDTO.Battery > 100) return TypedResults.BadRequest("Батарея має бути 0-100");
    phone.Name = phoneDTO.Name;
    phone.Battery = phoneDTO.Battery;
    phone.Price = phoneDTO.Price;
    phone.Iphone = phoneDTO.Iphone;
    phone.AppleID = phoneDTO.AppleID;
    await db.SaveChangesAsync();

    return TypedResults.NoContent();
}

static async Task<IResult> PatchPhone(int id, PhonePatchDto inputPhone, PhoneDb db)
{
    var phone = await db.Phones.FindAsync(id);

    if (phone is null)
        return TypedResults.NotFound($"Телефон з ID {id} не знайдено");

    if (inputPhone.Name is not null)
    {
        if (string.IsNullOrWhiteSpace(inputPhone.Name))
            return TypedResults.BadRequest("Назва не може бути порожньою");

        phone.Name = inputPhone.Name;
    }

    if (inputPhone.Price.HasValue)
    {
        if (inputPhone.Price.Value < 0)
            return TypedResults.BadRequest("Ціна не може бути від'ємною");

        phone.Price = inputPhone.Price.Value;
    }

    if (inputPhone.Battery.HasValue)
    {
        if (inputPhone.Battery.Value < 0 || inputPhone.Battery.Value > 100)
            return TypedResults.BadRequest("Батарея має бути від 0 до 100");

        phone.Battery = inputPhone.Battery.Value;
    }

    if (inputPhone.Iphone.HasValue)
        phone.Iphone = inputPhone.Iphone.Value;

    if (inputPhone.AppleID is not null)
        phone.AppleID = inputPhone.AppleID;

    if (!phone.Iphone)
    {
        if (!string.IsNullOrWhiteSpace(inputPhone.AppleID))
            return TypedResults.BadRequest(
                "Не можна вказувати AppleID, якщо Iphone = false");

        phone.AppleID = null;
    }

    await db.SaveChangesAsync();

    return TypedResults.Ok(new PhoneDTO(phone));
}

static async Task<IResult> DeletePhone(int id, PhoneDb db)
{
    if (await db.Phones.FindAsync(id) is Phone Phone)
    {
        db.Phones.Remove(Phone);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound($"Телефон з ID {id} не знайдено");
}