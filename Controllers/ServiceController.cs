using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gladiator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly GDbContext _context;

    public ServiceController(GDbContext context)
    {
        _context = context;
    }

    // GET: api/Services
    [HttpGet]
    public IActionResult GetServices()
    {
        var services = _context.Services.ToList();
        return Ok(services);
    }

    // POST: api/Services
    [HttpPost]
    public IActionResult PostService(Service service)
    {
        _context.Services.Add(service);
        _context.SaveChanges();

        return CreatedAtAction("GetService", new { id = service.ServiceID }, service);
    }

    // GET: api/Services/ServiceTypes
    [HttpGet("ServiceTypes")]
    public IActionResult GetServiceTypes()
    {
        var serviceTypes = _context.Services.Select(s => s.ServiceType).Distinct().ToList();
        return Ok(serviceTypes);
    }

    // DELETE: api/Services/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteService(int id)
    {
        var service = _context.Services.Find(id);
        if (service == null)
        {
            return NotFound();
        }

        _context.Services.Remove(service);
        _context.SaveChanges();

        return NoContent();
    }

    // PUT: api/Services/{id}
    [HttpPut("{id}")]
    public IActionResult PutService(int id, Service service)
    {
        if (id != service.ServiceID)
        {
            return BadRequest();
        }

        _context.Entry(service).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServiceExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool ServiceExists(int id)
    {
        return _context.Services.Any(e => e.ServiceID == id);
    }
}
