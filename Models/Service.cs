using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Gladiator.Models
{
    public class Service
{
    public int ServiceID { get; set; }
 
    public int ServiceType { get; set; }
 
    public string Description { get; set; }
 
    public string Requirements { get; set; }
 
    public decimal Charges { get; set; }
 
    public DateTime Timing { get; set; }
 
    public int Amount { get; set; }
 
    public DateTime CreatedTime { get; set; }
 
    public DateTime ModifiedTime { get; set; }
 
    public bool IsDeleted { get; set; }
 
    // Navigation property
    public ICollection<Booking> Bookings { get; set; }
}
}