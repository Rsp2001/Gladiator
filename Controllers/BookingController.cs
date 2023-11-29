using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gladiator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly GDbContext _context;

    public BookingController(GDbContext context)
    {
        _context = context;
    }

    // GET: api/Booking/GetAllBookings
    [HttpGet("GetAllBookings")]
    public IActionResult GetAllBookings()
    {
        var bookings = _context.Bookings.ToList();
        return Ok(bookings);
    }

    // GET: api/Booking/GetBookingsByUserId
    [HttpGet("GetBookingsByUserId")]
    public IActionResult GetBookingsByUserId(int userId)
    {
        var bookings = _context.Bookings.Where(b => b.UserID == userId).ToList();
        return Ok(bookings);
    }

    // POST: api/Booking/AddBooking
    [HttpPost("AddBooking")]
    public IActionResult AddBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return CreatedAtAction("GetBooking", new { id = booking.BookingID }, booking);
    }

    // DELETE: api/Booking/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteBooking(int id)
    {
        var booking = _context.Bookings.Find(id);
        if (booking == null)
        {
            return NotFound();
        }

        _context.Bookings.Remove(booking);
        _context.SaveChanges();

        return NoContent();
    }

    // PUT: api/Booking/{BookingID}
    [HttpPut("{BookingID}")]
    public IActionResult PutBooking(int BookingID, Booking booking)
    {
        if (BookingID != booking.BookingID)
        {
            return BadRequest();
        }

        _context.Entry(booking).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookingExists(BookingID))
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

    // PUT: api/Booking/ChangeStatus/{id}
    [HttpPut("ChangeStatus/{id}")]
    public IActionResult ChangeBookingStatus(int id, string status)
    {
        var booking = _context.Bookings.Find(id);
        if (booking == null)
        {
            return NotFound();
        }

        booking.BookingStatus = status;
        _context.SaveChanges();

        return NoContent();
    }

    private bool BookingExists(int id)
    {
        return _context.Bookings.Any(e => e.BookingID == id);
    }
}
