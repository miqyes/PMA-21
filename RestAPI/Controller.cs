using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly AplicationDb _context;

    public OrderController(AplicationDb context)
    {
        _context = context;
    }

    [HttpGet("{Id}")]
    public IActionResult GetOrder([FromRoute] int Id)
    {

        if (Id <= 0)
        {
            return BadRequest("Id has to be greater than 0.");
        }

        Order? CurrentOrder = _context.Orders.Find(Id);
        if (CurrentOrder == null)
        {
            return NotFound("Order with this ID not exists");
        }

        return Ok(CurrentOrder);
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] Order? NewOrder)
    {
        if (NewOrder == null)
        {
            return BadRequest("Data about order is empty.");
        }

        if (string.IsNullOrWhiteSpace(NewOrder.ProductName))
        {
            return BadRequest("Name has to be.");
        }

        if (NewOrder.Quantity <= 0)
        {
            return BadRequest("The quantity must be greater than 0.");
        }

        if (NewOrder.Price < 0)
        {
            return BadRequest("Price can not be negative.");
        }

        NewOrder.Id = 0;
        _context.Orders.Add(NewOrder);
        _context.SaveChanges();
        return Created($"/order/{NewOrder.Id}", NewOrder);
    }

    [HttpPatch("{Id}")]
    public IActionResult PatchOrder([FromRoute] int Id, [FromBody] OrderPatch? PatchData)
    {
        if (Id <= 0)
        {
            return BadRequest("ID must be greater than 0.");
        }

        if (PatchData == null)
        {
            return BadRequest("Data for update is missing.");
        }

        Order? ExistingOrder = _context.Orders.Find(Id);

        if (ExistingOrder == null)
        {
            return NotFound("Order with this ID not found.");
        }

        if (PatchData.Quantity <= 0)
        {
            return BadRequest("Quantity must be greater than 0.");
        }

        if (PatchData.Price < 0)
        {
            return BadRequest("Price can not be negative.");
        }

        ExistingOrder.Quantity = PatchData.Quantity;
        ExistingOrder.Price = PatchData.Price;

        _context.SaveChanges();
        return Ok(ExistingOrder);
    }

    [HttpDelete("{Id}")]
    public IActionResult DeleteOrder([FromRoute] int Id)
    {
        if (Id <= 0)
        {
            return BadRequest("Id must be greater than 0.");
        }

        Order? ExistingOrder = _context.Orders.Find(Id);
        if (ExistingOrder == null)
        {
            return NotFound("Order with this ID not found.");
        }

        _context.Orders.Remove(ExistingOrder);
        _context.SaveChanges();
        return Ok("Order deleted!");
    }
}