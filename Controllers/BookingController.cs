using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gladiator.Models;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly RiteshDbContext _context;

    public BookingController(RiteshDbContext context)
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
   // GET: api/Booking/GetBookingsByUserId
[HttpGet("GetBookingsByUserId")]
public IActionResult GetBookingsByUserId(int UserId)
{
    var booking = _context.Bookings.FirstOrDefault(b => b.UserID == UserId);
    // var bookings = _context.Bookings.Where(b => b.UserID == userId.ToString()).ToList();
    
    if (booking == null)
    {
        return NotFound();
    }

    return Ok(booking);
}


    // POST: api/Booking/AddBooking
    [HttpPost("AddBooking")]
    public IActionResult AddBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAllBookings), new { id = booking.BookingID }, booking);
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
    public IActionResult ChangeBookingStatus(int id, string newStatus)
    {
        var booking = _context.Bookings.Find(id);

        if (booking == null)
        {
            return NotFound();
        }

        booking.BookingStatus = newStatus;

        _context.SaveChanges();

        return NoContent();
    }

    private bool BookingExists(int id)
    {
        return _context.Bookings.Any(e => e.BookingID == id);
    }
}
