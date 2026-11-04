using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CosmeticsController : ControllerBase
{
    private readonly AppDbContext _db;

    public CosmeticsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cosmetic>>> GetAll()
    {
        return await _db.Cosmetics.OrderBy(c => c.Id).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cosmetic>> Get(int id)
    {
        var item = await _db.Cosmetics.FindAsync(id);
        if (item == null)
            return NotFound("Cosmetic with id=" + id + " not found");
        return item;
    }

    [HttpPost]
    public async Task<ActionResult<Cosmetic>> Create(Cosmetic cosmetic)
    {
        cosmetic.Id = 0;
        _db.Cosmetics.Add(cosmetic);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = cosmetic.Id }, cosmetic);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Cosmetic>> Update(int id, CosmeticPatch patch)
    {
        if (patch.Name != null && string.IsNullOrWhiteSpace(patch.Name))
            return BadRequest("Name cannot be empty");
        if (patch.Brand != null && string.IsNullOrWhiteSpace(patch.Brand))
            return BadRequest("Brand cannot be empty");
        if (patch.Price != null && patch.Price <= 0)
            return BadRequest("Price must be greater than 0");

        var item = await _db.Cosmetics.FindAsync(id);
        if (item == null)
            return NotFound("Cosmetic with id=" + id + " not found");

        if (patch.Name != null) item.Name = patch.Name;
        if (patch.Brand != null) item.Brand = patch.Brand;
        if (patch.Price != null) item.Price = patch.Price.Value;

        await _db.SaveChangesAsync();
        return item;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.Cosmetics.FindAsync(id);
        if (item == null)
            return NotFound("Cosmetic with id=" + id + " not found");

        _db.Cosmetics.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
