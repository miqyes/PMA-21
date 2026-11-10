using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Mapping.Data;
using Mapping.Model;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Mapping.UserController;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    
    private ContentResult XmlResponse<T>(T value, int statusCode = StatusCodes.Status200OK)
    {
        var serializer = new XmlSerializer(typeof(T));
        var xml = new StringBuilder();

        using (var writer = XmlWriter.Create(xml, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true }))
        {
            serializer.Serialize(writer, value);
        }

        return new ContentResult
        {
            Content = xml.ToString(),
            ContentType = "application/xml; charset=utf-8",
            StatusCode = statusCode
        };
    }

    private ContentResult NotFoundXml()
    {
        return new ContentResult
        {
            Content = "<Error>User not found</Error>",
            ContentType = "application/xml; charset=utf-8",
            StatusCode = StatusCodes.Status404NotFound
        };
    }
    
    public UserController(AppDbContext context) { _context = context; }
    
    // Додати
    [HttpPost]
    public async Task<ActionResult<UserDto>> Post(UserDto user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        return XmlResponse(user, StatusCodes.Status201Created);
    }
    
    // Оновити
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, UserDto newUser)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return NotFoundXml();

        if (!string.IsNullOrEmpty(newUser.Username))
            user.Username = newUser.Username;
        if (!string.IsNullOrEmpty(newUser.Email))
            user.Email = newUser.Email;
        if (!string.IsNullOrEmpty(newUser.ActivityTime))
            user.ActivityTime = newUser.ActivityTime;

        await _context.SaveChangesAsync();

        return XmlResponse(user);
    }

    
    
    // Отримати 
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<UserDto> users = await _context.Users.ToListAsync();
        return XmlResponse(users);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> Get(int id)
    {
        var target = await _context.Users.FindAsync(id);
        if (target == null) 
            return NotFoundXml();
        
        return XmlResponse(target);
    }

    

    // Видалення
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var target = await _context.Users.FindAsync(id);
        if (target == null)
            return NotFoundXml();

        _context.Users.Remove(target);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}