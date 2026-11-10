using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Client.Data;
using Client.Models;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace Client.Controllers;
    
[ApiController]
[Route("api/[controller]")]

public class ClientController : ControllerBase
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
    
    public ClientController (AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Models.Client>> Post(Models.Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return XmlResponse(client, StatusCodes.Status201Created);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Models.Client>>> Get(int? id)
    {
        
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
            return NotFound();  // 404

        return XmlResponse(client);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Models.Client> clients = await _context.Clients.ToListAsync();
        return XmlResponse(clients);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, Models.Client clientUpdate)
    {
        var client = await _context.Clients.FindAsync(id);

        if (client == null)
            return NotFoundXml(); // 404
        if (!string.IsNullOrEmpty(clientUpdate.FirstName))
            client.FirstName = clientUpdate.FirstName;
        if (!string.IsNullOrEmpty(clientUpdate.LastName))
            client.LastName = clientUpdate.LastName;
        if (!string.IsNullOrEmpty(clientUpdate.Email))
            client.Email = clientUpdate.Email;
        if (clientUpdate.Age != null)
            client.Age = clientUpdate.Age;
        
        // це для класу Date
        if (clientUpdate.DateOfBirth != null)
        {
            if (clientUpdate.DateOfBirth == null)
                client.DateOfBirth = new Date { Day = 1, Month = 1, Year = 2000 };

            if (clientUpdate.DateOfBirth.Day != 0)
                client.DateOfBirth.Day = clientUpdate.DateOfBirth.Day;

            if (clientUpdate.DateOfBirth.Month != 0)
                client.DateOfBirth.Month = clientUpdate.DateOfBirth.Month;

            if (clientUpdate.DateOfBirth.Year != 0)
                client.DateOfBirth.Year = clientUpdate.DateOfBirth.Year;
        }
        await _context.SaveChangesAsync();
        return XmlResponse(client);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFoundXml();
        }
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}