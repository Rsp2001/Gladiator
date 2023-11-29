using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gladiator.Models
{
 public class Booking
{
    [Key]
    public int BookingID { get; set; }
 
    [ForeignKey("UserCredentials")]
    public int UserID { get; set; }
 
    public string UserName { get; set; }
 
    public DateTime SubmissionDate { get; set; }
 
    public string Description { get; set; }
 
    public string BookingStatus { get; set; }
 
    [ForeignKey("Service")]
    public int ServiceID { get; set; }
 
    public DateTime CreatedTime { get; set; }
 
    public DateTime ModifiedTime { get; set; }
 
    public bool IsDeleted { get; set; }
 
    // Navigation properties
    public UserCredentials UserCredentials { get; set; }
 
    public Service Service { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
}